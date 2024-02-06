using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutting : MonoBehaviour
{
    [SerializeField] private GameObject cutBeforeObject;
    [SerializeField] private GameObject cutAfterObject;
    [SerializeField] private GameObject cutTarget;
    [SerializeField] private float velocitySpeed = 10;
    private Unparent unparentScript;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        unparentScript = GetComponent<Unparent>();
    }

    private void Update()
    {
        GetClick();
    }

    private void GetClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == cutBeforeObject)
                Cut();
        }
    }

    private void Cut()
    {
        cutBeforeObject.SetActive(false);
        cutAfterObject.SetActive(true);

        Rigidbody cutRb = cutTarget.AddComponent<Rigidbody>();
        cutRb.velocity = Vector3.down * velocitySpeed;

        unparentScript.CutRope();
    }
}