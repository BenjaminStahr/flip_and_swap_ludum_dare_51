using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    static int collected = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collected++;
        Destroy(SwapController.GI.FindCorresponding(gameObject));
        Destroy(gameObject);
    }
}
