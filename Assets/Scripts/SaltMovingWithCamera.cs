using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SaltMovingWithCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    private CharacterController controller;

    private Vector3 playerVelocity;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravityValue = -9.81f;

    [SerializeField] private Animator playerAnim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = mainCam.transform.right * moveHorizontal + mainCam.transform.forward * moveVertical;

        // normalize move if has a magnitude > 1 to prevent faster diagonal movement
        if (move.sqrMagnitude > 1)
        {
            move.Normalize();
            
            
               //    gameObject.transform.forward = move;
        }
        if(move != Vector3.zero)
        {
            playerAnim.SetBool("PlayAnim", true);
        }
        else
        {
            playerAnim.SetBool("PlayAnim", false);
        }

        controller.Move(move * speed);


        playerVelocity.y += gravityValue;
        controller.Move(playerVelocity);

    }
}

