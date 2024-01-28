using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextEffectLibrary;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextEffectComponent : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    [Range(0.01f, 2f)]
    [SerializeField] float timeBetweenLetters = 0.04f;
    [SerializeField]
    char[] waitCharacters = {
        '.',
        ',',
        '!',
        '?'
    };
    EffectLabel seTemEspera;
    TextFormat textoFormatado;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }
    public void WriteText(string newText)
    {
        textComponent.text = "";
        textoFormatado = TextEffect.FormataTexto(newText);
        if (textoFormatado == null)
        {
            return;
        }
        seTemEspera = null;
        foreach(EffectLabel el in textoFormatado.listaEfeitos)
        {
            if(el.type == "wait")
            {
                seTemEspera = el;
                break;
            }
        }
        StartCoroutine(WriteTextCoroutine(textoFormatado.text));
    }
    IEnumerator WriteTextCoroutine(string newText)
    {
        bool readingComand = false;
        string addCommand = "";
        for(int i = 0; i < newText.Length; i++)
        {
            if (newText[i] == '<')
            {
                readingComand = true;
                addCommand = "";
                addCommand += newText[i];
                continue;
            }
            if (readingComand)
            {
                addCommand += newText[i];
                if (newText[i] == '>')
                {
                    readingComand = false;
                    textComponent.text += addCommand;
                }
                continue;
            }
            textComponent.text += newText[i];
            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
            yield return new WaitForSeconds(timeBetweenLetters);
            if(seTemEspera != null)
            {
                if(i >= seTemEspera.startIndex && i < seTemEspera.endIndex)
                {
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                } else
                {
                    foreach (char a in waitCharacters)
                    {
                        if (a == newText[i])
                        {
                            yield return new WaitForSeconds(timeBetweenLetters);
                            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                            yield return new WaitForSeconds(timeBetweenLetters);
                            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                            yield return new WaitForSeconds(timeBetweenLetters);
                            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                            yield return new WaitForSeconds(timeBetweenLetters);
                            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                            yield return new WaitForSeconds(timeBetweenLetters);
                            break;
                        }
                    }
                }
            } else
            {
                foreach (char a in waitCharacters)
                {
                    if (a == newText[i])
                    {
                        yield return new WaitForSeconds(timeBetweenLetters);
                        TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                        yield return new WaitForSeconds(timeBetweenLetters);
                        TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                        yield return new WaitForSeconds(timeBetweenLetters);
                        TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                        yield return new WaitForSeconds(timeBetweenLetters);
                        TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                        yield return new WaitForSeconds(timeBetweenLetters);
                        break;
                    }
                }
            }
        }

        /*
        foreach (char c in newText)
        {
            if(c == '<')
            {
                readingComand = true;
                addCommand = "";
                addCommand += c;
                continue;
            }
            if (readingComand)
            {
                addCommand += c;
                if(c == '>')
                {
                    readingComand = false;
                    textComponent.text += addCommand;
                }
                continue;
            }
            textComponent.text += c;
            TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
            yield return new WaitForSeconds(timeBetweenLetters);


            
            foreach(char a in waitCharacters)
            {
                if(a == c)
                {
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    TextEffect.AtualizaEfeitos(textComponent, textoFormatado);
                    yield return new WaitForSeconds(timeBetweenLetters);
                    break;
                }
            }
        }*/
        StartCoroutine(TextEffect.ExeEffect(textComponent, textoFormatado, timeBetweenLetters));
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        //StopCoroutine(TextEffect.ExeEffect(textComponent, null, 0));
    }
}
