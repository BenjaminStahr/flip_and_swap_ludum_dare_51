using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpeedRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject rotChild;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float v = body.velocity.x;
        float angularV = v * Mathf.Rad2Deg;

        rotChild.transform.eulerAngles += new Vector3(0, 0, -angularV * Time.deltaTime);
    }
}
