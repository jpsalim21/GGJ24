using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaBalao : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    [SerializeField] float forca;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.AddForce(input * forca);
    }
}
