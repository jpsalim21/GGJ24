using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] Text texto;
    int contador = 0;
    void Start()
    {
        GameEvents.morreu += GalinhaMorreuFunc;
    }

    void GalinhaMorreuFunc(){
        contador++;
        string a = contador.ToString();
        texto.text = a;
    }
}