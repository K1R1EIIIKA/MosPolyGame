using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneLevelFive : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoodShtuka")
        {
            GameManager.Instance.Lose();
        }
    }
}
