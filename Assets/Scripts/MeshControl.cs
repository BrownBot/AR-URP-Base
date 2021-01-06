using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MeshControl : MonoBehaviour
{
    public Material Mat;
    public ARMeshManager MeshMan;
    
    private bool _meshVisible = true;

    public void OnMeshToggle()
    {
        _meshVisible = !_meshVisible;

        foreach (var mesh in MeshMan.meshes)
        {
            mesh.gameObject.GetComponent<MeshRenderer>().enabled = _meshVisible;
        } 
        // disable the prefab mesh also
        MeshMan.meshPrefab.gameObject.GetComponent<MeshRenderer>().enabled = _meshVisible;
    }

    public void OnOpacityUpdated(float opacity)
    {
        Mat.SetColor("_MainColor", new Color(0.2f, 0.4f, 0.8f, opacity));
    }
}
