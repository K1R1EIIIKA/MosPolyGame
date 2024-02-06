using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryingPanel : MonoBehaviour
{
    [SerializeField] private GameObject winTrigger;

    [Header("Параметры зелёного поля")]
    [SerializeField] private Slider miniGameSliderZone;
    [SerializeField] private float imagePosition;
    [SerializeField] private float speedOfZone;
    [SerializeField] private float spread;

    [Header("Параметры рандомно перемещающейся штуки")]
    [SerializeField] private Slider miniGameSlider;
    [SerializeField] private float minOfRange;
    [SerializeField] private float maxOfRange;
    [SerializeField] private float speedOfChange;
    [SerializeField] private int delayOfChange;
    private float currentNum;
    private float numNow;

    [Header("Параметры шкалы прогресса")]
    [SerializeField] private Slider progressSlider;
    [SerializeField] private float speedOfFillProgressSlider;
    [SerializeField] private float speedOfDevastationProgressSlider;

    private bool corutineActive;
    private bool isWin;
    private bool isWinActive;

    private void Start()
    {
        corutineActive = false;
        isWin = false;
        isWinActive = false;
    }
    
    private void Update()
    {
        if(!isWin)
        {
            RandomMovePurpose();
            ZoneMove();
            FillProgressBar();
            MiniGameWin();
        }
        else
        {
            if(!isWinActive)
            {
                winTrigger.SetActive(true);
                isWinActive = true;
            }
        }
    }

    private void DelayLogic()
    {
        StartCoroutine(DelayLogicCorutine(delayOfChange));
    }

    private IEnumerator DelayLogicCorutine(float delay)
    {
        corutineActive = true;
        yield return new WaitForSeconds(delay);
        currentNum = miniGameSlider.value;
        numNow = Random.Range(minOfRange, maxOfRange);
        corutineActive = false;
    }

    private void ZoneMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0)
        {
            if (moveHorizontal < 0 && !(imagePosition < minOfRange))
            {
                imagePosition += moveHorizontal * speedOfZone;
            }
            if (moveHorizontal > 0 && !(imagePosition > maxOfRange))
            {
                imagePosition += moveHorizontal * speedOfZone;
            }
        }
        miniGameSliderZone.value = imagePosition;
    }

    private void RandomMovePurpose()
    {
        if (!corutineActive)
        {
            DelayLogic();
        }
        currentNum = Mathf.Lerp(currentNum, numNow, speedOfChange * Time.deltaTime);
        miniGameSlider.value = currentNum;
    }

    private void FillProgressBar()
    {
        if (imagePosition + spread > currentNum && imagePosition - spread < currentNum)
        {
            progressSlider.value += speedOfFillProgressSlider;
        }
        else
        {
            progressSlider.value -= speedOfDevastationProgressSlider;
        }
    }

    private void MiniGameWin()
    {
        if(progressSlider.value >= 100)
        {
            isWin = true;
        }
    }
}
