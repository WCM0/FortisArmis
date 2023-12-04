using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTargetScript : MonoBehaviour
{

    public int _damage;
    public ParticleSystem _ParticleSystem;
  
    
    
    
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
            _ParticleSystem.Play();
            Destroy(gameObject);
           
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        
        
        
        if (other.tag == "Bullet")
        {
            Debug.Log("Hit! Damage +1 Points +50");

          
            _damage -= 1;
        }
    }

  

}


