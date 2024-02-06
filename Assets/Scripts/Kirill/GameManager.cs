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
    [HideInInspector] public bool isLose;
    
    [Header("Canvases")]
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject pauseCanvas;
    
    [Header("Milk")]
    public int milkCount = 0;
    public int milkNeeded = 4;
    
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
        SetTimeScale(1);
        AudioManager.Instance.Play("Main Theme");
    }

    public void Win()
    {
        Debug.Log("You win!");
        SetTimeScale(0);
            
        winCanvas.SetActive(true);
        isWon = true;
            
        Cursor.lockState = CursorLockMode.None;
        AudioManager.Instance.StopAllSoundType(SoundType.SFX);
        AudioManager.Instance.Play("Win");
    }
    
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        
        if (timeScale == 0)
            AudioManager.Instance.VolumeAll(0.5f, SoundType.Music);
        else
            AudioManager.Instance.VolumeAll(1, SoundType.Music);
    }

    public void Lose()
    {
        Debug.Log("You lose!");
        SetTimeScale(0);

        loseCanvas.SetActive(true);
        isLose = true;

        Cursor.lockState = CursorLockMode.None;
        AudioManager.Instance.StopAllSoundType(SoundType.SFX);
        AudioManager.Instance.Play("Lose");
    }
}
