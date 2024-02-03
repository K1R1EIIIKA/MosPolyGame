using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private int levelProgress;
    [SerializeField] private List<Button> levels;

    void Start()
    {
        levelProgress = PlayerPrefs.GetInt("LevelProgress");

        for(int i = 0; i <= levelProgress; i++)
        {
            levels[i].interactable = true;
        }
    } 
}
