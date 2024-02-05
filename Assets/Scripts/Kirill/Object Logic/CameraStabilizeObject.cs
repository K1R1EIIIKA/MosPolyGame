using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizeObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = Vector3.zero;
    
    void Update()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
