using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheScoreFromTheTimer : MonoBehaviour
{
    [SerializeField] private List<GameObject> stars;
    //[SerializeField] private GameObject starPanel;
    [SerializeField] private GameObject timerGO;
    [SerializeField] private List<int> lostStarsSeconds;
    private int countStars;
    private int starsNow;
    private Timer timerScript;
    private int currentSeconds;

    private void Start()
    {
        timerScript = timerGO.GetComponent<Timer>();
        countStars = lostStarsSeconds.Count;
        starsNow = (stars.Count - countStars) + countStars;
        CheckStars();
    }

    private void CheckStars()
    {
        for (int i = 0; i < countStars; i++)
        {
            CheckTime();
            if (lostStarsSeconds[i] < currentSeconds)
            {
                starsNow--;
            }
        }
        //starPanel.SetActive(true); 
        StarsShow();

    }

    private void StarsShow()
    {
        for(int i = 0; i < starsNow; i++)
        {
            stars[i].SetActive(true);
        }
    }

    private void CheckTime()
    {
        currentSeconds = timerScript.OutPutSeconds();
    }
}
