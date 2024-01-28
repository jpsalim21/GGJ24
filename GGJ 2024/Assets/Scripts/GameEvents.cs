using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action Restart;
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
}
