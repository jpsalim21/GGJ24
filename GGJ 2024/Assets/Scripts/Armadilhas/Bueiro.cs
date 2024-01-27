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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            GalinhaController.gc.gameObject.SetActive(false);
            anim.SetTrigger("Bueiro");
        }
    }
}
