using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerOfScene : MonoBehaviour
{
    public int numberOfScene;

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(numberOfScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
