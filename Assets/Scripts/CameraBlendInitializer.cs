using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBlendInitializer : MonoBehaviour
{
    [SerializeField] private float blendPeriod;
    [SerializeField] public Material blendLightMaterial;
    [SerializeField] public Material blendDarkMaterial;
    //private ShaderController shaderController;
    private bool dark;

    float current;

    void Start()
    {
        blendLightMaterial.SetFloat("_Period", blendPeriod);
        blendLightMaterial.SetFloat("_StartTime", -float.MaxValue);
        blendDarkMaterial.SetFloat("_Period", blendPeriod);
        blendDarkMaterial.SetFloat("_StartTime", -float.MaxValue);
        current = Time.time;
        dark = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //blendLightMaterial.SetFloat("_StartTime", Time.time);
            //blendDarkMaterial.SetFloat("_StartTime", Time.time);
            if (!dark)
            {
                blendLightMaterial.SetFloat("_StartTime", Time.time);

                //blendDarkMaterial.SetFloat("_StartTime", Time.time);
                dark = !dark;
            }
            else 
            {
                blendDarkMaterial.SetFloat("_StartTime", Time.time);
                //blendDarkMaterial.SetFloat("_StartTime", Time.time);
                dark = !dark;
            }
            
            /*if (Time.time - current > 10) 
            {
                blendMaterial.SetFloat("_StartTime", Time.time);
                current = Time.time;
            }*/
        }
    }
}
