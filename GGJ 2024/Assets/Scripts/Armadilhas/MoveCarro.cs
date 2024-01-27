using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarro : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Vector2 destino;
    [SerializeField] float speed, tempoDesativar;
    Vector2 direcao;

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
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = direcao * speed;
    }
}
