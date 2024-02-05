using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PanTarget"))
        {
            Debug.Log("You win!");
            Time.timeScale = 0;
            
            GameManager.Instance.winCanvas.SetActive(true);
            
            AudioManager.Instance.Play("Win");
        }
    }
}
