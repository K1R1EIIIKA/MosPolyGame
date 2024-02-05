using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material glowMaterial;
    public Material aimGlowMaterial;
    public Material aimWithoutSelectionGlowMaterial;
    
    // public CinemachineFreeLook freeLookCamera;
    public GameObject cameraPrefab;

    // public Transform staticCameraPos;
    public CinemachineVirtualCamera vcam;
    public CinemachineVirtualCamera vcamMouseTrap;
    
    public bool isInTheMouseTrap;

    public GameObject cross;
    [HideInInspector] public bool isWon;
    
    [Header("Canvases")]
    public GameObject winCanvas;
    public GameObject pauseCanvas;
    
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        Debug.Log("You win!");
        //Time.timeScale = 0;
            
        winCanvas.SetActive(true);
        isWon = true;
            
        Cursor.lockState = CursorLockMode.None;
        AudioManager.Instance.StopAllSoundType(SoundType.SFX);
        AudioManager.Instance.Play("Win");
    }
}
