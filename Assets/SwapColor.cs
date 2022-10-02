using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwapColor : MonoBehaviour
{
    private SpriteRenderer rnd;

    [SerializeField]
    private Color darkColor;

    [SerializeField]
    private Color lightColor;

    [SerializeField]
    private bool refresh;

    private void Start()
    {
        rnd = GetComponent<SpriteRenderer>();
        Refresh();
    }

    private void Update()
    {
        if (refresh)
        {
            Refresh();
        }
    }

    void Refresh()
    {
        if (transform.position.x > 500)
        {
            rnd.color = darkColor;
        }
        else
        {
            rnd.color = lightColor;
        }
    }
}
