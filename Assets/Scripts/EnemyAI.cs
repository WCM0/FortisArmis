using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Transform gunTransform;  // Reference to the gun's transform
    public GameObject bulletPrefab;  // Prefab of the bullet
    public Transform firePoint;  // Point where the bullet is instantiated
    public float detectionRadius = 200f;  // Radius to detect the player
    public float attackRange = 180f;  // Range to start shooting
    public float shootInterval = 0.5f;  // Time interval between shots
    public float bulletSpeed = 10f;  // Speed of the bullet
    public float moveSpeed = 5f;  // Enemy movement speed

    private NavMeshAgent navMeshAgent;


    private bool canShoot = true;

    public AudioSource gunSound;

    void Start()
     {
     //Get the NavMeshAgent component attached to the enemy
      navMeshAgent = GetComponent<NavMeshAgent>();

     if (navMeshAgent == null)
     {
          Debug.LogError("NavMeshAgent component not found on enemy.");
       }
     }

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
           

            // Player is detected, set destination to player's position
            navMeshAgent.SetDestination(player.position);

            // Check if the player is within attack range
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                // Aim at the player
                Vector3 targetDirection = player.position - transform.position;
                Quaternion newRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 5f);

                

                // Check if the enemy can shoot
                if (canShoot)
                {
                    // Shoot at the player
                    Shoot();
                    

                    // Set the shooting cooldown
                    canShoot = false;
                    Invoke("ResetShootCooldown", shootInterval);
                }
            }
        }
    }

    void Shoot()
    {
        // Instantiate a bullet and set its velocity
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;

        gunSound.Play();

        // You can add additional logic here, such as dealing damage or playing a shooting sound
    }

    void ResetShootCooldown()
    {
        canShoot = true;
    }
}
