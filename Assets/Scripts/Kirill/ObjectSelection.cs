using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    [SerializeField] private bool isCameraMove;

    private MeshRenderer _meshRenderer;
    private Camera _mainCamera;
    private ObjectSelection[] _selectObjects;

    private GameObject vcamObject;

    private bool _isSelected;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _mainCamera = Camera.main;
        _selectObjects = FindObjectsOfType<ObjectSelection>();
    }

    private void Start()
    {
        DeselectAll();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckClick())
        {
            if (!_isSelected)
                Select();
            else
                Deselect();
        }
        
        if (Input.GetMouseButton(0) && _isSelected)
            UnlockCamera();
        
        if (Input.GetMouseButtonUp(0) && _isSelected)
            LockCamera();

        if (Input.GetKeyDown(KeyCode.E))
            DeselectAll();
    }

    private bool CheckClick()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private void Select()
    {
        List<Material> materials = _meshRenderer.materials.ToList();

        if (!materials.Contains(GameManager.Instance.glowMaterial))
        {
            materials.Add(GameManager.Instance.glowMaterial);

            if (isCameraMove)
                SetCamera();

            foreach (ObjectSelection selectObject in _selectObjects)
            {
                if (selectObject._isSelected && selectObject != this)
                    selectObject.Deselect();
            }

            _meshRenderer.SetMaterials(materials);
            _isSelected = true;
        }
    }

    private void SetCamera()
    {
        vcamObject = Instantiate(GameManager.Instance.cameraPrefab, transform.position, Quaternion.identity);
        CinemachineFreeLook vcam = vcamObject.GetComponent<CinemachineFreeLook>();
        
        LockCamera();

        vcam.Follow = transform;
        vcam.LookAt = transform;

        vcam.Priority = 11;
    }

    private void Deselect()
    {
        List<Material> materials = _meshRenderer.materials.ToList();
        materials.Remove(materials[^1]);

        _meshRenderer.SetMaterials(materials);
        _isSelected = false;

        vcamObject.GetComponent<CinemachineFreeLook>().Priority = 0;

        Destroy(vcamObject, 1.5f);
    }

    public void DeselectAll()
    {
        foreach (var selectObject in _selectObjects)
        {
            if (selectObject._isSelected)
                selectObject.Deselect();
        }
    }

    private void LockCamera()
    {
        vcamObject.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
        vcamObject.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 0;
    }
    
    private void UnlockCamera()
    {
        vcamObject.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 300;
        vcamObject.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = 2;
    }
}