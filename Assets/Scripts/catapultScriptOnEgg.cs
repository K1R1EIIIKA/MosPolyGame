using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class catapultScriptOnEgg : MonoBehaviour
{
    [SerializeField] private MonoBehaviour movingScript;
    
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 direction;
    
    [SerializeField] private float power;

    
    //[SerializeField] private Slider upAndDownSlider;
    //[SerializeField] private Slider leftAndRightSlider;
    [SerializeField] private Slider powerSlider;

    private Rigidbody rb;

    [SerializeField] private GameObject catapultPanel;
    [SerializeField] private GameObject aim;
    
    [SerializeField] private bool inCatapult = false;
    
    [SerializeField] private Transform gunPoint;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //direction = new Vector3(-upAndDownSlider.value, leftAndRightSlider.value, 0f);
        //aim.transform.rotation = Quaternion.Euler(direction);

        if(inCatapult)
        {
            transform.LookAt(gunPoint);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Catapult")
        {
            catapultPanel.SetActive(true);
            inCatapult = true;
            movingScript.enabled = false;
            rb.isKinematic = true;
            transform.position = collision.transform.position + offset;
        }
    }

    public void Fire()
    {
        inCatapult = false;
        power = powerSlider.value;
        movingScript.enabled = true;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
        catapultPanel.SetActive(false);
    }


}
