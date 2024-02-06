using System;
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
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (TryGetComponent(out ObjectSelection selection))
        {
            if (selection.isSelected)
                SetRollingSound();
        }

        Vector3 move = mainCam.transform.right * moveHorizontal + mainCam.transform.forward * moveVertical;
        if (move.sqrMagnitude > 1)
        {
            move.Normalize();
        }

        rb.AddForce(move * speed);
        
    }

    private void SetRollingSound()
    {
        float eggSpeed = rb.velocity.magnitude;

        if (eggSpeed > 5)
        {
            AudioManager.Instance.ChangeSoundPitch("Egg Rolling", Mathf.Clamp(0.5f + (eggSpeed - 5) / 10, 0.4f, 1f));
            AudioManager.Instance.ChangeSoundVolume("Egg Rolling", Mathf.Clamp(AudioManager.Instance.GetSoundVolume("Egg Rolling") + 0.1f, 0.1f, 1f));
        }
        else if (eggSpeed <= 5 && eggSpeed > 2)
        {
            AudioManager.Instance.ChangeSoundPitch("Egg Rolling", Mathf.Clamp(0.5f + (eggSpeed - 2) / 10, 0.4f, 1f));
            AudioManager.Instance.ChangeSoundVolume("Egg Rolling", Mathf.Clamp(AudioManager.Instance.GetSoundVolume("Egg Rolling") - 0.1f, 0.1f, 1f));
        }
        else if (eggSpeed >= movingLimit && eggSpeed <= 2)
        {
            AudioManager.Instance.ChangeSoundPitch("Egg Rolling", Mathf.Clamp(0.5f + (eggSpeed - 1) / 10, 0.4f, 1f));
            AudioManager.Instance.ChangeSoundVolume("Egg Rolling", Mathf.Clamp(AudioManager.Instance.GetSoundVolume("Egg Rolling") - 0.1f, 0.1f, 1f));
        }
        else if (eggSpeed < movingLimit && eggSpeed > 0.1f)
        {
            AudioManager.Instance.ChangeSoundPitch("Egg Rolling", Mathf.Clamp(0.5f + (eggSpeed - 0.1f) / 10, 0.4f, 1f));
            AudioManager.Instance.ChangeSoundVolume("Egg Rolling", Mathf.Clamp(AudioManager.Instance.GetSoundVolume("Egg Rolling") - 0.1f, 0.1f, 1f));
        }

        Debug.Log(AudioManager.Instance.GetSoundPitch("Egg Rolling"));
        
        if (eggSpeed >= movingLimit && !AudioManager.Instance.IsPlaying("Egg Rolling"))
            FindObjectOfType<AudioManager>().Play("Egg Rolling");
        else if (eggSpeed <= movingLimit)
            FindObjectOfType<AudioManager>().Stop("Egg Rolling");
    }

    // private void OnDisable()
    // {
    //     if (AudioManager.Instance.IsPlaying("Egg Rolling"))
    //         AudioManager.Instance.Stop("Egg Rolling");
    // }

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
