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
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        Debug.Log("Parou");
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log(rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        rb.AddForce(input * forca);
    }
}
