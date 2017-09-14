﻿using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour 
{
    [ContextMenu("Convert to regular mesh")]
    void Convert()
    {
        var skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        var meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
