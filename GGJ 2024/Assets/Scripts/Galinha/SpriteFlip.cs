using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    bool direita = true;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direita && rb.velocity.x < 0)
        {
            sp.flipX = true;
            direita = false;
        } else if(!direita && rb.velocity.x > 0)
        {
            sp.flipX = false;
            direita = true;
        }
    }
}
