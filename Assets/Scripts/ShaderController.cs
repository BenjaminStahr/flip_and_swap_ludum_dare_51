using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    [SerializeField] public Camera lightCam;
    [SerializeField] public Camera darkCam;
    // Start is called before the first frame update
    void Start()
    {
        lightCam.enabled = true;
        darkCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightCam.enabled = !lightCam.enabled;
            darkCam.enabled = !darkCam.enabled;
        }
    }
}
