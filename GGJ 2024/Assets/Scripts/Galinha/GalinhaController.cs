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

    public Vector2 spawnPoint;
    [SerializeField] GameObject resto;

    bool dead = false;

    bool voando = false;

    void Start()
    {
        spawnPoint = transform.position;
        gc = this;
        rb = GetComponent<Rigidbody2D>();
    }

    
    public void ChangeState(EstadosGalinha novoEstado)
    {
        estadoAtual.scriptReferente.enabled = false;
        estadoAtual.spriteReferente.SetActive(false);
        switch (novoEstado)
        {
            case EstadosGalinha.normal:
                estadoAtual = listaEstados[0];
                break;
            case EstadosGalinha.fuzil:
                estadoAtual = listaEstados[1];
                StartCoroutine("tempoPowerUp");
                break;
            case EstadosGalinha.bota:
                estadoAtual = listaEstados[2];
                StartCoroutine("tempoPowerUp");
                break;
            case EstadosGalinha.balao:
                estadoAtual = listaEstados[3];
                voando = true;
                StartCoroutine("tempoPowerUp");
                break;
            default:
                break;
        }
        estadoAtual.scriptReferente.enabled = true;
        estadoAtual.spriteReferente.SetActive(true);
    }
    IEnumerator tempoPowerUp()
    {
        yield return new WaitForSeconds(10);
        ChangeState(EstadosGalinha.normal);
        voando = false;
    }

    public void Reviver()
    {
        estadoAtual.spriteReferente.SetActive(false);
        dead = true;
        StartCoroutine(respawn(false));
    }
    IEnumerator respawn(bool deveInstanciar)
    {
        Debug.Log(deveInstanciar);
        yield return new WaitForSeconds(0.7f);
        if (deveInstanciar) Instantiate(resto, transform.position, Quaternion.identity);
        transform.position = spawnPoint;
        dead = false;
        estadoAtual.spriteReferente.GetComponent<Animator>().SetTrigger("Reset");
        estadoAtual.spriteReferente.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        ChangeState(EstadosGalinha.normal);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 && !dead && !voando)
        {
            Debug.Log("Morreu");
            dead = true;
            StopCoroutine("tempoPowerUp");
            estadoAtual.scriptReferente.enabled = false;
            estadoAtual.spriteReferente.GetComponent<SpriteRenderer>().sortingLayerName = "PowerUp";
            rb.velocity = Vector2.zero;
            estadoAtual.spriteReferente.GetComponent<Animator>().SetTrigger("Die");
            StartCoroutine(respawn(true));

        }
    }
}
