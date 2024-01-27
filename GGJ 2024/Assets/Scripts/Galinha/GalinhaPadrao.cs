using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaPadrao : MonoBehaviour
{
    Vector2 input;
    Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

    }
    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }
}
