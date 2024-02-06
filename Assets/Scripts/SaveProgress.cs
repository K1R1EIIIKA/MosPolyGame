using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveProgress : MonoBehaviour
{
    private int levelProgress;
    private int currentLevel;

    public void Start()
    {
        levelProgress = PlayerPrefs.GetInt("LevelProgress");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void SaveLevelProgress()
    {
        if (currentLevel > levelProgress)
        {
            levelProgress++;
            PlayerPrefs.SetInt("LevelProgress", levelProgress);
        }
    }

    public void DeleteData()
    {
        AudioManager.Instance.Play("New Game");
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene(num);
    }
}
