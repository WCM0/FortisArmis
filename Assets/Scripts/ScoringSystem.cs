using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int catsCollected;
    public int totalCrates = 30;
    
    //public AudioSource collectSound;
    //public AudioSource catSound;


    public GameObject shelterHighlight;


    void Start()
    {
        shelterHighlight.SetActive(false);
    }


    void Update()
    {

        scoreText.GetComponent<Text>().text = catsCollected + "/" + totalCrates;


       if(catsCollected == 30)
        {
            shelterHighlight.SetActive(true);
        }
       
        
    }

    


}
