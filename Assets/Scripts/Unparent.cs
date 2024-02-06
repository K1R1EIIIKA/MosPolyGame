using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparent : MonoBehaviour
{
    [SerializeField] private Transform shtuka;
    [SerializeField] private Vector3 offset;
    private bool onRope;

    private void Start()
    {
        onRope = true;
    }
    
    private void Update()
    {
        if(onRope)
        {
            shtuka.position = transform.position + offset;
        }
    }

    public void CutRope()
    {
        onRope = false;
    }
}
