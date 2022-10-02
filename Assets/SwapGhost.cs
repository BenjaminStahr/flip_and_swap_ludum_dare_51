using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class SwapGhost : MonoBehaviour
{    
    public enum Home
    {
        Dark,
        Light
    }

    [SerializeField]
    public Home home;

    [SerializeField]
    private Sprite ghostSprite;

    void initHome() 
    {
        Collider2D collider = GetComponent<Collider2D>();
        SpriteRenderer rnd = GetComponent<SpriteRenderer>();

        bool homeDark = home == Home.Dark;
        bool dark = transform.position.x > 500;

        bool isGhost = homeDark != dark;

        Animator anim;
        if (TryGetComponent(out anim))
        {
            anim.enabled = !isGhost;
        }

        collider.enabled = !isGhost;
        if (isGhost)
        {
            rnd.sprite = ghostSprite;
        }
    }

    private void Start()
    {
        initHome();
    }
    public bool ReinitHome() 
    {
        bool homeFlag;
        if (home == Home.Dark)
        {
            home = Home.Light;
            homeFlag = false;
        }
        else
        {
            home = Home.Dark;
            homeFlag = true;
        }
        //Collider2D collider = GetComponent<Collider2D>();
        //SpriteRenderer rnd = GetComponent<SpriteRenderer>();
        //collider.enabled = false;
        //rnd.sprite = ghostSprite;
        return homeFlag;
    }
}
