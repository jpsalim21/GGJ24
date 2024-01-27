using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoTrigger : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (objeto == null) return;
            objeto.SetActive(true);
        }
    }
}
