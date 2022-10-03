using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 10f;
    public int lastShotStart = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (lastShotStart + 0.5f < Time.time) 
            {
                if (GameObject.FindGameObjectWithTag("Game") != null)
                {
                    GameObject.FindGameObjectWithTag("Game").GetComponent<PlaySounds>().shoot.Play();
                }
                GameObject proj = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                proj.GetComponent<Rigidbody2D>().velocity = proj.transform.right * speed;
            }
        }
    }
}
