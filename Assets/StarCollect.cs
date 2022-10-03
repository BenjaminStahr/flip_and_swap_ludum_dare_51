using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    static int collected = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Game") != null)
            {
                GameObject.FindGameObjectWithTag("Game").GetComponent<PlaySounds>().collect1.Play();
            }

            collected++;
            Destroy(SwapController.GI.FindCorresponding(gameObject));
            Destroy(gameObject);
        }
    }
}
