using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MilkChange : MonoBehaviour
{
    [SerializeField] private Material milkMaterial;

    public void ChangeMilk()
    {
        List<Material> materials = GetComponent<MeshRenderer>().materials.ToList();
        
        materials[0] = milkMaterial;
        GetComponent<MeshRenderer>().SetMaterials(materials);
    }
}
