using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggMovingWithCamera : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float speed = 2; // скорость передвижения
    [SerializeField] private float movingLimit = 0.5f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 jump;
    [SerializeField] private Camera mainCam;

    void Start()
    {
        // Получить доступ к компоненту Rigidbody
        rb = GetComponent<Rigidbody>();
        CheckPointLogic.Instance.SpawnOnCheckPoint(gameObject);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal + " " + moveVertical + " " + FindObjectOfType<AudioManager>().IsPlaying("Egg Rolling"));
        if ((moveHorizontal != 0 || moveVertical != 0) && !FindObjectOfType<AudioManager>().IsPlaying("Egg Rolling"))
            FindObjectOfType<AudioManager>().Play("Egg Rolling");
        else if (moveHorizontal == 0 && moveVertical == 0)
            FindObjectOfType<AudioManager>().Stop("Egg Rolling");

        Vector3 move = mainCam.transform.right * moveHorizontal + mainCam.transform.forward * moveVertical;
        if (move.sqrMagnitude > 1)
        {
            move.Normalize();
        }

        rb.AddForce(move * speed);
        
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
