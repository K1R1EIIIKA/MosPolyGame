using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stopwatch;

    private int seconds;
    private int minutes;
    private int hours;

    private bool corutineActive;


    private void Start()
    {
        corutineActive = false;
    }

    private void Update()
    {
        if(!corutineActive)
        {
            DelayLogic();
            TimeTransformations();
        }
        
        Print();
    }

    private void DelayLogic()
    {
        StartCoroutine(DelayLogicCorutine(1));
    }

    private IEnumerator DelayLogicCorutine(float delay)
    {
        corutineActive = true;
        yield return new WaitForSeconds(delay);
        seconds++;
        corutineActive = false;
    }

    private void TimeTransformations()
    {
        if (seconds >= 60)
        {
            minutes++;
            seconds -= 60;
        }
        if (minutes >= 60)
        {
            hours++;
            minutes -= 60;
        }
    }

    private void Print()
    {
        stopwatch.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    public int OutPutSeconds()
    {
        return seconds;
    }
}
