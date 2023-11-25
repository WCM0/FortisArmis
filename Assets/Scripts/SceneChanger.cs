using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
   public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void ReloadGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
