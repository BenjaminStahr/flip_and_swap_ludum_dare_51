using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameObject.FindGameObjectWithTag("Game") != null)
            {
                GameObject.FindGameObjectWithTag("Game").GetComponent<PlaySounds>().collect2.Play();
            }
            collision.gameObject.GetComponent<Controller>().GunCollect();
            Destroy(SwapController.GI.FindCorresponding(gameObject));
            Destroy(gameObject);
        }
    }
}
