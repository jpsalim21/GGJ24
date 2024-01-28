using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoTrigger : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    Vector2 startPoint;
    [SerializeField] float time;

    void Start()
    {
        startPoint = objeto.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (objeto == null) return;
            objeto.SetActive(true);
        }
    }
    IEnumerator esperaRestart()
    {
        yield return new WaitForSeconds(time);
        objeto.transform.position = startPoint;
        objeto.SetActive(true);
    }
}
