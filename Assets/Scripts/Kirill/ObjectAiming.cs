using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectAiming : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private ObjectSelection _objectSelection;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _objectSelection = GetComponent<ObjectSelection>();
    }

    private void OnMouseEnter()
    {
        if (_objectSelection.isSelected || _objectSelection.isTransitioning)
            return;
        
        List<Material> materials = _meshRenderer.materials.ToList();
        
        materials.Add(GameManager.Instance.aimGlowMaterial);
        
        _meshRenderer.materials = materials.ToArray();
    }
    
    private void OnMouseExit()
    {
        if (_objectSelection.isTransitioning)
            return;

        List<Material> materials = _meshRenderer.materials.ToList();

        foreach (Material material in materials)
        {
            if (material.name.Contains("Aim Glow"))
            {
                materials.Remove(material);
                break;
            }
        }
        
        _meshRenderer.materials = materials.ToArray();
    }
}
