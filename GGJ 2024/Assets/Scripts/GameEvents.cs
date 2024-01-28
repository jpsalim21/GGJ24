using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action Restart;
    public static event Action morreu;
    public static GameEvents ge;

    private void Start()
    {
        ge = this;
    }

    public void GalinhaMorreuFunc()
    {
        if(Restart != null)
        {
            Restart();
        }
    }
    public void GalinhaMorreu(){
        if(morreu != null){
            morreu();
        }
    }
}
