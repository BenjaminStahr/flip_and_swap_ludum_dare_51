using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Controller>().GunCollect();
            Destroy(SwapController.GI.FindCorresponding(collision.gameObject));
            Destroy(gameObject);
        }
    }
}
