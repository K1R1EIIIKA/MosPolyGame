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
                Destroy(other);
                milk.SetActive(true);
                isMilked = true;
            }
        }
    }
}
