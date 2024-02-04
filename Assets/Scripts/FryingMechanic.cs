using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingMechanic : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movingScript;
    
    [SerializeField] private float fryingTimeSeconds;

    //[SerializeField] private float 

    private Rigidbody rb;
    
    [SerializeField] private GameObject PanPanel;

    [SerializeField] private Vector3 offset;

    //[SerializeField] private bool inPan = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator DelayLogicCorutine(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
    
    public void DelayLogic()
    {
        StartCoroutine(DelayLogicCorutine(fryingTimeSeconds));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pan")
        {
            PanPanel.SetActive(true);
            //inCatapult = true;
            movingScript.enabled = false;
            rb.isKinematic = true;
            transform.position = collision.transform.position + offset;
        }
    }
}
