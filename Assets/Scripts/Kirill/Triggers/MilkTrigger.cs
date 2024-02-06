using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkTrigger : MonoBehaviour
{
    [SerializeField] private GameObject milk;
    
    [HideInInspector] public bool isMilked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PanTarget"))
        {
            if (!isMilked)
            {
                other.GetComponent<ObjectSelection>().Deselect();
                other.GetComponent<MilkChange>().ChangeMilk();
                other.GetComponent<ObjectSelection>().enabled = false;
                other.GetComponent<ObjectAiming>().action = ObjectAiming.ObjectAction.None;
                
                milk.SetActive(true);
                isMilked = true;
                GameManager.Instance.milkCount++;
                if (GameManager.Instance.milkCount >= GameManager.Instance.milkNeeded)
                    GameManager.Instance.Win();
            }
        }
    }
}