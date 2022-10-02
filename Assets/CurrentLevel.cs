using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField]
    private int currentLevelID = 1;

    public int CurrentLevelID 
    { 
        get => currentLevelID; 
        set { currentLevelID = value; Refresh(); } 
    }

    public static CurrentLevel GI { get => gi; }
    static CurrentLevel gi;

    // Start is called before the first frame update
    void Start()
    {
        gi = this;
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
