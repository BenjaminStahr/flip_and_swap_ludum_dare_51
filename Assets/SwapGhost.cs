using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class SwapGhost : MonoBehaviour
{    
    enum Home
    {
        Dark,
        Light
    }

    [SerializeField]
    private Home home;

    bool isGhost;

    [SerializeField]
    private Sprite ghostSprite;

    private void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        SpriteRenderer rnd = GetComponent<SpriteRenderer>();

        bool homeDark = home == Home.Dark;
        bool dark = transform.position.x > 500;

        isGhost = homeDark != dark;

        Animator anim;
        if (TryGetComponent(out anim))
        {
            anim.enabled = !isGhost;
        }

        collider.enabled = !isGhost;
        if (isGhost && ghostSprite != null)
        {
            rnd.sprite = ghostSprite;
        }
    }

    private void Update()
    {
        if (isGhost)
        {
            GameObject other = SwapController.GI.FindCorresponding(gameObject);
            this.transform.localPosition = other.transform.localPosition;
        }
    }
}
