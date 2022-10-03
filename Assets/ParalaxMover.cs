using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMover : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;

    private Vector3 startpos;

    private void Start()
    {
        startpos = transform.localPosition;
    }

    void Update()
    {
        Vector3 delta = camera.transform.localPosition - startpos;
        transform.localPosition = startpos + delta * 0.5f;
    }
}
