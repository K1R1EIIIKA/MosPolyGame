using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggWalking : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float speed = 2; // скорость передвижения
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 jump;
    [SerializeField] private Transform camera;

    private bool _isMoving;

    void Start()
    {
        // Получить доступ к компоненту Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Нажатие стрелочки влево или вправо
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Нажатие стрелочки вперёд или назад
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * camera.eulerAngles.y;
            Vector3 movement = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
            rb.AddForce(movement * speed);
        }       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
