using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTargetScript : MonoBehaviour
{

    public int _damage;
    public ParticleSystem _ParticleSystem;

    public ParticleSystem _BulletStrike;

    public AudioSource _RicochetSound;
    
    // Start is called before the first frame update
    void Start()
    {


        _damage = 5;
      

    }

    // Update is called once per frame
    void Update()
    {
       
        if(_damage == 0)
        {
          StartCoroutine(EnemyDestroy());
           
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        
        
        
        if (other.tag == "Bullet")
        {
            Debug.Log("Hit! Damage +1 Points +50");
            _BulletStrike.Play();
            _RicochetSound.Play();
            _damage -= 1;
        }
    }

  IEnumerator EnemyDestroy()
    {
       _ParticleSystem.Play();
        

       yield return new WaitForSeconds(0.1f);

        
       Destroy(gameObject);
    }

}


