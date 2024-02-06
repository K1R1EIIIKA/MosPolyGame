using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultRotation : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    [SerializeField] private GameObject aim;
    private float leftAndRight;
    private float upAndDown;
    [SerializeField] private float upLimit;
    [SerializeField] private float downLimit;
    [SerializeField] private float speedOfRotation;


    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0f)
        {
            leftAndRight -= speedOfRotation;
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            leftAndRight += speedOfRotation;
        }
        if (Input.GetAxis("Vertical") > 0f && upAndDown < upLimit)
        {
            upAndDown += speedOfRotation;
        }
        if (Input.GetAxis("Vertical") < 0f && upAndDown > downLimit)
        {
            upAndDown -= speedOfRotation;
        }
        direction = new Vector3(-upAndDown, leftAndRight, 0f);
        aim.transform.rotation = Quaternion.Euler(direction);
    }
}
