using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GalinhaController : MonoBehaviour
{
    [System.Serializable] struct StructEstado
    {
        public EstadosGalinha estado;
        public MonoBehaviour scriptReferente;
        public GameObject spriteReferente;
    }
    [SerializeField] StructEstado[] listaEstados;
    [SerializeField] StructEstado estadoAtual;

    public static GalinhaController gc;
    Rigidbody2D rb;
    Animator anim;

    bool dead = false;

    void Start()
    {
        gc = this;
        rb = GetComponent<Rigidbody2D>();
        anim = estadoAtual.spriteReferente.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(EstadosGalinha novoEstado)
    {
        if(novoEstado == estadoAtual.estado)
        {
            return;
        }
        estadoAtual.scriptReferente.enabled = false;
        switch (novoEstado)
        {
            case EstadosGalinha.normal:
                estadoAtual = listaEstados[0];
                break;
            case EstadosGalinha.fuzil:
                estadoAtual = listaEstados[1];
                break;
            case EstadosGalinha.bota:
                estadoAtual = listaEstados[2];
                break;
            default:
                break;
        }
        estadoAtual.scriptReferente.enabled = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 && !dead)
        {
            Debug.Log("Morreu");
            dead = true;
            estadoAtual.scriptReferente.enabled = false;
            estadoAtual.spriteReferente.GetComponent<SpriteRenderer>().sortingLayerName = "PowerUp";
            rb.velocity = Vector2.zero;
            anim.SetTrigger("Die");

        }
    }
}
