using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] private GameObject EasterEggPanel;
    [SerializeField] private int timeToClosePanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EasterEgg")
        {
            Destroy(collision.gameObject);
            EasterEggPanel.SetActive(true);
            DelayLogic();
        }
    }

    private void DelayLogic()
    {
        StartCoroutine(DelayLogicCorutine(timeToClosePanel));
    }

    private IEnumerator DelayLogicCorutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        EasterEggPanel.SetActive(false);
    }

}
