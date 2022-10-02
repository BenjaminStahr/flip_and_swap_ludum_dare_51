using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHome : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bool dark = GameObject.FindGameObjectWithTag("Game").GetComponent<SwapController>().dark;
        if (!dark)
        {
            
            GameObject level = gameObject.transform.parent.gameObject;
            int objIndex = 0;
            for (int i = 0; i < level.transform.childCount; i++)
            {
                if (level.transform.GetChild(i) == gameObject.transform)
                {
                    objIndex = i;

                }
            }
            GameObject darkLevel = GameObject.FindGameObjectWithTag("LevelOneDark");
            GameObject shadow = darkLevel.transform.GetChild(objIndex).gameObject;
            Vector2 position = gameObject.transform.localPosition;
            Transform newParent = darkLevel.transform;
            gameObject.transform.SetParent(newParent);
            gameObject.transform.localPosition = position;
            shadow.transform.SetParent(level.transform);
            shadow.transform.localPosition = position;
        }
        else 
        {
            GameObject level = gameObject.transform.parent.gameObject;
            int objIndex = 0;
            for (int i = 0; i < level.transform.childCount; i++)
            {
                if (level.transform.GetChild(i) == gameObject.transform)
                {
                    objIndex = i;

                }
            }
            GameObject lightLevel = GameObject.FindGameObjectWithTag("LevelOneLight");
            GameObject shadow = lightLevel.transform.GetChild(objIndex).gameObject;
            Vector2 position = gameObject.transform.localPosition;
            Transform newParent = lightLevel.transform;
            gameObject.transform.SetParent(newParent);
            gameObject.transform.localPosition = position;
            shadow.transform.SetParent(level.transform);
            shadow.transform.localPosition = position;  
        }
    }
}
