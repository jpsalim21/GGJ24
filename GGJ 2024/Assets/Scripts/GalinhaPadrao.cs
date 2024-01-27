using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaPadrao : MonoBehaviour
{
    Vector2 input;
    Rigidbody2D rb;
    [SerializeField] float speed;

    bool dash = false;
    [SerializeField] float dashTime, dashSpeed;
    float dashTimePassed = 0;
    Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        if (Input.GetKeyDown(KeyCode.Space) && dashTimePassed <= 0)
        {
            dashTimePassed = dashTime;
            dash = true;
            dashDirection = input;
        }
        if(dashTimePassed > 0)
        {
            dashTimePassed -= Time.deltaTime;
        } else if (dash)
        {
            dash = false;
        }

    }
    private void FixedUpdate()
    {
        if (!dash)
        {
            rb.velocity = input * speed;
        } else
        {
            rb.velocity = dashDirection * dashSpeed;
        }
    }
}
