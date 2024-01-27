using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPick : MonoBehaviour
{
    [SerializeField] EstadosGalinha estado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            GalinhaController.gc.ChangeState(estado);
            Destroy(this.gameObject);
        }
    }
}
