using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHome : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet")) 
        {
            GameObject.FindGameObjectWithTag("Game").GetComponent<PlaySounds>().swap.Play();
            SwapController.GI.SwapLevelObject(gameObject);
        }
        
    }
}
