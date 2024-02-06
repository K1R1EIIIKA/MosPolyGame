using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChangeTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera newCamera;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PanTarget"))
        {
            VirtualCameraLogic.Instance.ChangeCamera(newCamera);
        }
    }
}
