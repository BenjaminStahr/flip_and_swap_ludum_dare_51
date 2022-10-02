using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHome : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet")) 
        {
            SwapController.GI.SwapLevelObject(gameObject);
            //Destroy(col.gameObject);
        }
        
    }
}
