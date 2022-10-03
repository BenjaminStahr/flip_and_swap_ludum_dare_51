using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField]
    private int currentLevelID = 1;

    private static int level;

    public static int CurrentLevelID 
    { 
        get => level; 
        set { 
            level = value; 
            gi_dark.Refresh(); 
            gi_light.Refresh();
            GameObject lightCam = GameObject.FindGameObjectWithTag("LightCamera");
            lightCam.GetComponent<CamControl>().enabled = false;
            lightCam.transform.localPosition = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player")
                .GetComponent<Controller>().LevelStart();
            lightCam.GetComponent<CamControl>().enabled = true;
        } 
    }

    public static GameObject Dark { get => gi_dark.transform.GetChild(CurrentLevelID-1).gameObject; }
    static CurrentLevel gi_dark;
    public static GameObject Light { get => gi_light.transform.GetChild(CurrentLevelID - 1).gameObject; }
    static CurrentLevel gi_light;

    void Awake()
    {
        if (transform.parent.CompareTag("Dark"))
        {
            level = currentLevelID;
            gi_dark = this;
        }
        else
        {
            level = currentLevelID;
            gi_light = this;
        }
        Refresh();        
    }

    void Refresh()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {            
            transform.GetChild(i).gameObject.SetActive(i == CurrentLevelID-1);
        }
    }

}
