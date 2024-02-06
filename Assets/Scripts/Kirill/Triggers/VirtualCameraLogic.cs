using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VirtualCameraLogic : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> virtualCameras;

    public static VirtualCameraLogic Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void ChangeCamera(CinemachineVirtualCamera newCamera)
    {
        foreach (var vCamera in virtualCameras)
        {
            vCamera.Priority = 0;
        }
        
        newCamera.Priority = 10;
    }
}
