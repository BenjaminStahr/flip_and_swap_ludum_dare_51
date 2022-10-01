using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour
{
    [SerializeField]
    private float distance = 100f;
    [SerializeField]
    private float world = 1;
    [SerializeField]
    private float numberOfWorlds = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (world < numberOfWorlds)
            {
                gameObject.transform.Translate(distance, 0,0);
                world++;
            }
            else
            {
                gameObject.transform.Translate(distance*-1*(numberOfWorlds-1), 0,0);
                world = 1;
            }
        }
    }
}
