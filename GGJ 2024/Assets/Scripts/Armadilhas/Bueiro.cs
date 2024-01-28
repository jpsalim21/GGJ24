using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bueiro : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9 && !GalinhaController.gc.voando)
        {
            anim.SetTrigger("Bueiro");
            GalinhaController.gc.Reviver();
        }
    }
}
