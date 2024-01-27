using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    bool direita = true;
    [SerializeField] int multiplicador = 1;
    float valorScale;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        valorScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(direita && rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-valorScale * multiplicador, transform.localScale.y, transform.localScale.z);
            direita = false;
        } else if(!direita && rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(valorScale * multiplicador, transform.localScale.y, transform.localScale.z);
            direita = true;
        }
    }
}
