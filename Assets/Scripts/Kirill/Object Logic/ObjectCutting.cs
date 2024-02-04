using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutting : MonoBehaviour
{
    [SerializeField] private GameObject cutBeforeObject;
    [SerializeField] private GameObject cutAfterObject;
    [SerializeField] private GameObject cutTarget;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
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

        cutTarget.AddComponent<Rigidbody>();
    }
}