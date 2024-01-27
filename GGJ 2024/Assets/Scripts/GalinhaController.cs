using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GalinhaController : MonoBehaviour
{
    [System.Serializable] struct StructEstado
    {
        public EstadosGalinha estado;
        public MonoBehaviour scriptReferente;
    }
    [SerializeField] StructEstado[] listaEstados;
    StructEstado estadoAtual;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeState(EstadosGalinha novoEstado)
    {
        if(novoEstado == estadoAtual.estado)
        {
            return;
        }
        estadoAtual.scriptReferente.enabled = false;
        switch (novoEstado)
        {
            case EstadosGalinha.normal:
                break;
            case EstadosGalinha.fuzil:
                break;
            case EstadosGalinha.bota:
                break;
            default:
                break;
        }

    }
}
