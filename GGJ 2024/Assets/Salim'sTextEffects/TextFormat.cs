using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextEffectLibrary;

public class EffectLabel {
    public string type;
    public int startIndex;
    public int endIndex;
    public string originalText;
    public EffectLabel(string _type, int _startIndex, int _endIndex)
    {
        type = _type;
        startIndex = _startIndex;
        endIndex = _endIndex;
    }
}
public class TextFormat
{
    public string text;
    public EffectLabel[] listaEfeitos;
    public int listaEfeitosIndex;
    public TextFormat()
    {
        text = "";
        listaEfeitos = new EffectLabel[10];
        listaEfeitosIndex = 0;
    }
}
