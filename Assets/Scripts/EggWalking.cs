using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggWalking : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float speed = 2; // �������� ������������
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 jump;

    void Start()
    {
        // �������� ������ � ���������� Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // ������� ��������� ����� ��� ������
        float moveHorizontal = Input.GetAxis("Horizontal");

        // ������� ��������� ����� ��� �����
        float moveVertical = Input.GetAxis("Vertical");

        // ����������� ����
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
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
