﻿using System.Collections;
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
    [SerializeField] GameObject resto, penas;

    bool dead = false;

    public bool voando = false;

    bool deveInstanciar = true;

    [SerializeField] AudioClip morrer;
    AudioSource audioSource;

    float tempoPup = 6;

    void Start()
    {
        spawnPoint = transform.position;
        gc = this;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    
    public void ChangeState(EstadosGalinha novoEstado)
    {
        estadoAtual.scriptReferente.enabled = false;
        estadoAtual.spriteReferente.SetActive(false);
        StopAllCoroutines();
        switch (novoEstado)
        {
            case EstadosGalinha.normal:
                estadoAtual = listaEstados[0];
                voando = false;
                break;
            case EstadosGalinha.fuzil:
                estadoAtual = listaEstados[1];
                voando = false;
                tempoPup = 8;
                StartCoroutine("tempoPowerUp");
                break;
            case EstadosGalinha.bota:
                estadoAtual = listaEstados[2];
                voando = false;
                tempoPup = 7;
                StartCoroutine("tempoPowerUp");
                break;
            case EstadosGalinha.balao:
                estadoAtual = listaEstados[3];
                voando = true;
                tempoPup = 4;
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
        yield return new WaitForSeconds(tempoPup);
        ChangeState(EstadosGalinha.normal);
        voando = false;
    }

    public void Reviver()
    {
        estadoAtual.spriteReferente.SetActive(false);
        dead = true;
        deveInstanciar = false;
        StartCoroutine(respawn());
    }
    IEnumerator respawn()
    {
        audioSource.PlayOneShot(morrer);
        GameEvents.ge.GalinhaMorreu();
        if(voando) Instantiate(penas, transform.position + Vector3.up * 2.5f, Quaternion.identity);
        Debug.Log(deveInstanciar);
        yield return new WaitForSeconds(0.7f);
        GameEvents.ge.GalinhaMorreuFunc();
        if (deveInstanciar) {
            GameObject a = Instantiate(resto, transform.position, Quaternion.identity);
            a.transform.localScale = estadoAtual.spriteReferente.transform.localScale;
        }
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
            deveInstanciar = true;
            StartCoroutine(respawn());

        }
        if(collision.gameObject.layer == 10 && !dead && voando)
        {
            dead = true;
            deveInstanciar = false;
            StopCoroutine("tempoPowerUp");
            estadoAtual.scriptReferente.enabled = false;
            estadoAtual.spriteReferente.SetActive(false);
            rb.velocity = Vector2.zero;
            StartCoroutine(respawn());
        }
    }
}
