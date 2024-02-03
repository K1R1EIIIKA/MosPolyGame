using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerOfScene : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene(int numberOfScene)
    {
        SceneManager.LoadScene(numberOfScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
