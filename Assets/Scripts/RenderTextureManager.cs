using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureManager : MonoBehaviour
{
    [SerializeField] private Material setToMaterial;

    void Awake()
    {
        var tex = new RenderTexture(Screen.width, Screen.height, 8);
        Camera cam = GetComponent<Camera>();
        cam.targetTexture = tex;
        setToMaterial.SetTexture("_BlendTex", tex);
    }
}