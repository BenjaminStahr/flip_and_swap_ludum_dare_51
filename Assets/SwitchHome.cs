using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHome : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet")) 
        {
            GameObject other = SwapController.GI.FindCorresponding(gameObject);
            //Destroy(other.GetComponent<Rigidbody2D>());
            //Destroy(GetComponent<Rigidbody2D>());
            //other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            SwapController.GI.SwapLevelObject(gameObject);
            //Destroy(col.gameObject);
        }
        
    }
}
