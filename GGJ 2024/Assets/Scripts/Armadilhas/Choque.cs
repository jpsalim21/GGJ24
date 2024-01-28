using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
    [SerializeField] GameObject setActive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9 && !GalinhaController.gc.voando)
        {
            setActive.transform.position = GalinhaController.gc.gameObject.transform.position;
            setActive.SetActive(true);
            GalinhaController.gc.Reviver();
            StartCoroutine("volta");
        }
    }

    IEnumerator volta()
    {
        yield return new WaitForSeconds(0.7f);
        setActive.SetActive(false);
    }

}
