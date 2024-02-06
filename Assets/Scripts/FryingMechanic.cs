using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingMechanic : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movingScript;
    
    private Rigidbody rb;
    
    [SerializeField] private GameObject PanPanel;

    [SerializeField] private Vector3 offset;

    [SerializeField] private bool inPan = false;

    [SerializeField] private MeshRenderer firstState;
    [SerializeField] private GameObject secondState;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pan")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
            firstState.enabled = false;
            secondState.SetActive(true);
            PanPanel.SetActive(true);
            inPan = true;
            movingScript.enabled = false;
            rb.isKinematic = true;
            transform.position = collision.transform.position + offset;
            
            AudioManager.Instance.Play("Egg Frying");
        }
    }
}
