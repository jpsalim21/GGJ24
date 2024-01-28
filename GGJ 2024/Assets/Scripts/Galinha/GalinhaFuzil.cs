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
    Quaternion lookDirection;

    [SerializeField] GameObject bala;

    float timeBuff = 0.1f, timeBuffPassed = 0;
    AudioSource sons;
    [SerializeField] AudioClip audio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sons = GetComponent<AudioSource>();
        sons.clip = audio;
        Debug.Log(Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timeBuffPassed = timeBuff;
            direction = Vector2.up;
            lookDirection = Quaternion.AngleAxis(90, Vector3.forward);
            sons.PlayOneShot(audio);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            timeBuffPassed = timeBuff;
            direction = Vector2.left;
            lookDirection = Quaternion.AngleAxis(180, Vector3.forward);
            sons.PlayOneShot(audio);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            timeBuffPassed = timeBuff;
            direction = Vector2.right;
            lookDirection = Quaternion.identity;
            sons.PlayOneShot(audio);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            timeBuffPassed = timeBuff;
            direction = Vector2.down;
            lookDirection = Quaternion.AngleAxis(-90, Vector3.forward);
            sons.PlayOneShot(audio);
        }

        if(timeBuffPassed > 0)
        {
            if (!dashing)
            {
                StartDash(direction, lookDirection);
                timeBuffPassed = 0;
            }
            timeBuffPassed -= Time.deltaTime;
        }

        if(timeDashPassed > 0)
        {
            timeDashPassed -= Time.deltaTime;
        } else if (dashing)
        {
            dashing = false;
        }
    }
    void StartDash(Vector2 dir, Quaternion q)
    {
        Tiro t = Instantiate(bala, transform.position, q).GetComponent<Tiro>();
        t.direction = -dir;
        timeDashPassed = timeDash;
        dashing = true;
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
