using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCountdown : MonoBehaviour
{
    public GameObject gameCountdown;
    public GameObject gameOverText;

    public GameObject buttonPanel;

    public static int secondsLeft = 40;
    public bool takingAway = false;


    // Start is called before the first frame update
    void Start()
    {
        
        gameCountdown.GetComponent<Text>().text = "" + secondsLeft;
        buttonPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (takingAway == false && secondsLeft < 1)
        {
            gameCountdown.GetComponent<Text>().text = "XX";
            gameOverText.GetComponent<Text>().text = "GAME OVER";

            buttonPanel.SetActive(true);
        }



    }


    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        gameCountdown.GetComponent<Text>().text = "" + secondsLeft;
        takingAway = false;

    }



}
