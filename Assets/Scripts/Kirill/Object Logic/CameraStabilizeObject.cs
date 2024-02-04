using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizeObject : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    void Update()
    {
        transform.position = target.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
