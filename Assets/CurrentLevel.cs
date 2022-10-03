using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField]
    private int currentLevelID = 1;

    public static int CurrentLevelID 
    { 
        get => gi_light.currentLevelID; 
        set { gi_light.currentLevelID = value; gi_dark.Refresh(); gi_light.Refresh(); } 
    }

    public static GameObject Dark { get => gi_dark.transform.GetChild(CurrentLevelID-1).gameObject; }
    static CurrentLevel gi_dark;
    public static GameObject Light { get => gi_light.transform.GetChild(CurrentLevelID - 1).gameObject; }
    static CurrentLevel gi_light;

    void Awake()
    {
        if (transform.parent.CompareTag("Dark"))
        {
            gi_dark = this;
        }
        else
        {
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
