﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarro : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 destino;
    [SerializeField] float speed, tempoDesativar;
    Vector2 direcao;
    [SerializeField] bool shouldDestroy = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcao = destino - (Vector2)transform.position;
        direcao.Normalize();
    }
    private void OnEnable()
    {
        StartCoroutine("desativar");
    }
    IEnumerator desativar()
    {
        yield return new WaitForSeconds(tempoDesativar);
        if (shouldDestroy) Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        rb.velocity = direcao * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }

}
