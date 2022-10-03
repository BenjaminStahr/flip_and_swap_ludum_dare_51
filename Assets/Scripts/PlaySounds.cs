using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioSource main;
    public AudioSource jump;
    public AudioSource swap;
    public AudioSource collect1;
    public AudioSource collect2;
    public AudioSource shoot;
    public AudioSource levelClear;
    public AudioSource death;

    // Start is called before the first frame update
    void Start()
    {
        main.loop = true;
        main.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
}
