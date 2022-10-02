using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBlendInitializer : MonoBehaviour
{
    [SerializeField] private float blendPeriod;
    [SerializeField] public Material blendLightMaterial;
    [SerializeField] public Material blendDarkMaterial;
    //private ShaderController shaderController;
    float animationDuration = 0.4f;
    float animationStart = 0;


    void Start()
    {
        blendLightMaterial.SetFloat("_Period", blendPeriod);
        blendLightMaterial.SetFloat("_StartTime", -float.MaxValue);
        blendDarkMaterial.SetFloat("_Period", blendPeriod);
        blendDarkMaterial.SetFloat("_StartTime", -float.MaxValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > animationStart + animationDuration)
        {
            blendLightMaterial.SetFloat("_Pixelate", 4000);
            blendDarkMaterial.SetFloat("_Pixelate", 4000);
        }
        else
        {
            int pixFactor = Random.RandomRange(120, 180);
            blendLightMaterial.SetFloat("_Pixelate", pixFactor);
            blendDarkMaterial.SetFloat("_Pixelate", pixFactor);
        }
    }

    public void Swap(bool dark)
    {
        if (!dark)
        {
            blendLightMaterial.SetFloat("_Period", 0.4f);
            blendLightMaterial.SetFloat("_StartTime", Time.time);
            animationStart = Time.time;
        }
        else
        {
            blendDarkMaterial.SetFloat("_StartTime", Time.time);
            blendDarkMaterial.SetFloat("_Period", 0.4f);
            animationStart = Time.time;
        }
    }
}
