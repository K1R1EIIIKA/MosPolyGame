using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("Menu Theme");
    }
}
