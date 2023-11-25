using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public PlayerInput _playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform _cameraTransform;


    [SerializeField]
    private float playerSpeed = 40.0f;
    [SerializeField]
    private float jumpHeight = 10f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float bulletHitMissDistance = 25f;

    [SerializeField]
    private float fireRate = 60f;


    public ParticleSystem shellOut;

    public AudioSource gunSound;



    WaitForSeconds rapidFireWait;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;


  

    //private float _currentVelocity;


    Coroutine _RapidFire;

    

    //[SerializeField]
    //private float smoothTime = 0.5f;

    private void Awake()
    {

       

        _cameraTransform = Camera.main.transform;

        rapidFireWait = new WaitForSeconds(1 / fireRate);


        controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        moveAction = _playerInput.actions["Move"];
        
        jumpAction = _playerInput.actions["Jump"];
        shootAction = _playerInput.actions["FireGun"];
        //pauseGame = _playerInput.actions["Pause"];
        
        //Cursor.lockState = CursorLockMode.Locked;

        

    }





    void Update()
    {

       

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

       

        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0, input.y);

       move = move.x * _cameraTransform.right.normalized + move.z * _cameraTransform.forward.normalized;

       move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed * 4);

        //if (input.sqrMagnitude == 0) return;

        //var playerDirection = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
        //var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, playerDirection, ref _currentVelocity, smoothTime);
        //transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);


       // if (move != Vector3.zero)
       // {
       //     gameObject.transform.forward = move;
       // }

        

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        // Rotate towards camera direction

        Quaternion targetRotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);


       


    }


    private void FixedUpdate()
    {
        shootAction.started += _ => StartFiring();
        shootAction.canceled += _ => StopFiring();
    }


    private void ShootGun()
    {
        RaycastHit hit;

        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();


        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity))
        {


            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = _cameraTransform.position + _cameraTransform.forward * bulletHitMissDistance;
            bulletController.hit = false;


        }
    }


  

    void StartFiring()
    {
       _RapidFire = StartCoroutine(RapidFire());
        shellOut.Play();
        gunSound.Play();
    }


   void StopFiring()
    {
       if(_RapidFire != null)
        {
            StopCoroutine(_RapidFire);
            shellOut.Stop();
            gunSound.Stop();
        }
       
    }







    public IEnumerator RapidFire()
    {
        while (true)
        {
            ShootGun();
           
            
            yield return rapidFireWait;
        }
    }

  
}