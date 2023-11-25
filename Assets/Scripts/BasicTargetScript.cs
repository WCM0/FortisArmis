using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTargetScript : MonoBehaviour
{

    public int _damage;

  
    
    
    
    // Start is called before the first frame update
    void Start()
    {


        _damage = 3;
      

    }

    // Update is called once per frame
    void Update()
    {
       
        if(_damage == 0)
        {
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


