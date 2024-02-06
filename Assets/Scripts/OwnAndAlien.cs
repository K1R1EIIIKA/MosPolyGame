using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnAndlien : MonoBehaviour
{
    [SerializeField] private int requiredValue;
    [SerializeField] private bool isWin;
    [SerializeField] private GameObject losePanel;

    private int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (!isWin && score >= requiredValue)
        {
            isWin = true;
            GameManager.Instance.Win();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoodShtuka")
        {
            score++;
        }
        if (collision.gameObject.tag == "BadShtuka")
        {
            losePanel.SetActive(true);
        }
    }
}
