using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalinhaFuzil : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed, timeDash;
    float timeDashPassed = 0;
    bool dashing = false;
    Vector2 direction = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashing)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = Vector2.up;
                timeDashPassed = timeDash;
                dashing = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector2.left;
                timeDashPassed = timeDash;
                dashing = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector2.right;
                timeDashPassed = timeDash;
                dashing = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = Vector2.down;
                timeDashPassed = timeDash;
                dashing = true;
            }
        }

        if(timeDashPassed > 0)
        {
            timeDashPassed -= Time.deltaTime;
        } else if (dashing)
        {
            dashing = false;
        }

    }
    private void FixedUpdate()
    {
        if (dashing)
        {
            rb.velocity = direction * speed;
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
