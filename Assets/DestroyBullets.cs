using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    float currentTime;
    bool startAnimateSmall = false;
    float startTime;
    // Start is called before the first frame update
    private void Start()
    {
        currentTime = Time.time;
    }
    private void Update()
    {
        if (Time.time > currentTime + 5) 
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        startAnimateSmall = true;
        startTime = Time.time;

    }
    private void FixedUpdate()
    {
        if (startAnimateSmall) 
        {
            this.gameObject.transform.localScale = this.gameObject.transform.localScale * (startTime + 1 - Time.time);
            if (this.gameObject.transform.localScale.x <= 0.001) 
            {
                Destroy(gameObject);
            }
        }
    }
}
