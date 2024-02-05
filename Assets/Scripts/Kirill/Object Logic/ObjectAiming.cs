using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectAiming : MonoBehaviour
{
    public enum ObjectAction
    {
        None,
        Select,
        Cut
    }
    
    private MeshRenderer _meshRenderer;
    private ObjectSelection _objectSelection;
    public ObjectAction action;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _objectSelection = GetComponent<ObjectSelection>();
    }

    private void OnMouseEnter()
    {
        if (_objectSelection && (_objectSelection.isSelected || _objectSelection.isTransitioning))
            return;
        
        List<Material> materials = _meshRenderer.materials.ToList();

        AddMaterial(materials);
        
        _meshRenderer.materials = materials.ToArray();
    }
    
    private void AddMaterial(List<Material> materials)
    {
        switch (action)
        {
            case ObjectAction.None:
                materials.Add(GameManager.Instance.aimWithoutSelectionGlowMaterial);
                break;
            case ObjectAction.Select: case ObjectAction.Cut:
                materials.Add(GameManager.Instance.aimGlowMaterial);
                break;
        }
    }
    
    private void OnMouseExit()
    {
        if (_objectSelection && _objectSelection.isTransitioning)
            return;

        List<Material> materials = _meshRenderer.materials.ToList();

        RemoveAimGlow(materials);
        
        _meshRenderer.materials = materials.ToArray();
    }

    public static void RemoveAimGlow(List<Material> materials)
    {
        foreach (Material material in materials)
        {
            if (material.name.Contains("Aim Glow") || material.name.Contains("AimWithoutSelect Glow"))
            {
                materials.Remove(material);
                break;
            }
        }
    }
}
