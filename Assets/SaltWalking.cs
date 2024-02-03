using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltWalking : MonoBehaviour
{
    private CharacterController controller;  
    private Vector3 playerVelocity;  
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [SerializeField] private Animator playerAnim;
    private void Start()  
    {  
        controller = gameObject.GetComponent<CharacterController>();  
    }

    void Update()  
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));  
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            playerAnim.SetBool("PlayAnim", true);
            //    gameObject.transform.forward = move;
        }
        else
        {
            playerAnim.SetBool("PlayAnim", false);
        }


    }

    void FixedUpdate()
    {
        playerVelocity.y += gravityValue;
        controller.Move(playerVelocity);
    }
}

