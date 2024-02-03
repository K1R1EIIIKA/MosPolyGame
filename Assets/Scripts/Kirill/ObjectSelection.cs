using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    [SerializeField] private bool isCameraMove;
    [SerializeField] private MonoBehaviour scriptToDisable;

    private MeshRenderer _meshRenderer;
    private Camera _mainCamera;
    private ObjectSelection[] _selectObjects;

    private GameObject _vcamObject;

    [NonSerialized] public bool isSelected;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _mainCamera = Camera.main;
        _selectObjects = FindObjectsOfType<ObjectSelection>();
    }

    private void Start()
    {
        DeselectAll();
        SetMoving(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckClick())
        {
            if (!isSelected)
                Select();
            else
                Deselect();
        }
        
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
                if (selectObject.isSelected && selectObject != this)
                    selectObject.Deselect();
            }

            _meshRenderer.SetMaterials(materials);
            isSelected = true;
            
            SetMoving(true);
        }
    }

    private void SetCamera()
    {
        _vcamObject = Instantiate(GameManager.Instance.cameraPrefab, transform.position, Quaternion.identity);
        CinemachineFreeLook vcam = _vcamObject.GetComponent<CinemachineFreeLook>();
        
        vcam.Follow = transform;
        vcam.LookAt = transform;

        vcam.Priority = 11;
    }

    private void Deselect()
    {
        List<Material> materials = _meshRenderer.materials.ToList();
        materials.Remove(materials[^1]);

        _meshRenderer.SetMaterials(materials);
        isSelected = false;

        _vcamObject.GetComponent<CinemachineFreeLook>().Priority = 0;

        Destroy(_vcamObject, 1.5f);
        
        SetMoving(false);
    }

    public void DeselectAll()
    {
        foreach (var selectObject in _selectObjects)
        {
            if (selectObject.isSelected)
                selectObject.Deselect();
        }
    }

    private void SetMoving(bool isMoving)
    {
        scriptToDisable.enabled = isMoving;
    }
}