using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [HideInInspector] public bool isCurrent;
    
    private bool isChecked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PanTarget") && !isChecked)
        {
            isChecked = true;
            CheckPointLogic.Instance.SetCheckPoint(gameObject);
        }
    }
}
