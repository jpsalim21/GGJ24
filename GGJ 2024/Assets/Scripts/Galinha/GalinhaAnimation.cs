using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("v", rb.velocity.magnitude);
    }
}
