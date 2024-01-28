using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPick : MonoBehaviour
{
    [SerializeField] EstadosGalinha estado;
    SpriteRenderer sp;
    bool ativo = true;

    private void Start()
    {
        GameEvents.Restart += Restart;
        sp = GetComponent<SpriteRenderer>();
    }
    void Restart()
    {
        sp.enabled = true;
        ativo = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9 && ativo)
        {
            GalinhaController.gc.ChangeState(estado);
            sp.enabled = false;
            ativo = false;
        }
    }
}
