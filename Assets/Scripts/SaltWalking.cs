using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltWalking : MonoBehaviour
{
    private CharacterController controller;  
    private Vector3 playerVelocity;  
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Transform camera;

    [SerializeField] private Animator playerAnim;
    private void Start()  
    {  
        controller = gameObject.GetComponent<CharacterController>();  
    }

    void Update()  
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Нажатие стрелочки вперёд или назад
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * camera.eulerAngles.y;
            Vector3 movement = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
            controller.Move(movement * Time.deltaTime * playerSpeed);
            //if (true)
            //{
            //    playerAnim.SetBool("PlayAnim", true);
            //    //    gameObject.transform.forward = move;
            //}
            //else
            //{
            //    playerAnim.SetBool("PlayAnim", false);
            //}
            //rb.AddForce(movement * speed);
        }
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));  
        

        
    }

    private void OnDisable()
    {
        playerAnim.SetBool("PlayAnim", false);
    }

    void FixedUpdate()
    {
        playerVelocity.y += gravityValue;
        controller.Move(playerVelocity);
    }
}

