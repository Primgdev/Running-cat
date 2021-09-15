using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void StartApp()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
        {
        SceneManager.LoadScene(0);

    }


    public void OnApplicationQuit()
    {
        Application.Quit();

    }
}
