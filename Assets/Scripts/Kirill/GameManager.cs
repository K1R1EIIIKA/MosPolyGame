using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material glowMaterial;
    public Material aimGlowMaterial;
    
    // public CinemachineFreeLook freeLookCamera;
    public GameObject cameraPrefab;

    // public Transform staticCameraPos;
    public CinemachineVirtualCamera vcam;

    public GameObject cross;
    
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
