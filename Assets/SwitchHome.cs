using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHome : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("asdf");
        SwapController.GI.SwapLevelObject(gameObject);
    }
}
