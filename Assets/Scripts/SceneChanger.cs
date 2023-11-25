using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
   public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ReloadGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Catch-A-Cat_Ver1.0", LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
