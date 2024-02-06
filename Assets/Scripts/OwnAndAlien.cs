using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnAndlien : MonoBehaviour
{
    [SerializeField] private int requiredValue;
    [SerializeField] private bool isWin;

    [SerializeField] private int score;
    [SerializeField] private GameObject omlete;

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
            omlete.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoodShtuka")
        {
            score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BadShtuka")
        {
            GameManager.Instance.Lose();
        }
    }
}
