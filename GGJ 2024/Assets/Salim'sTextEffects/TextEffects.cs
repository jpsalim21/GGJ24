using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextEffectLibrary;
using TMPro;

namespace TextEffectLibrary
{
    public static class TextEffect
    {
        private static string[] efeitosReais = {"w", "sw", "sl", "st", "rainbow", "jump", "wait"};
        private static void UpdateMeshGeometry(TextMeshProUGUI textComponent)
        {
            var textInfo = textComponent.textInfo;

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                meshInfo.mesh.colors32 = meshInfo.colors32;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
                textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }
        }
        private static void WoobleEffectText(TextMeshProUGUI textComponent, float amp, float freq, int inicio, int final)
        {
            var textInfo = textComponent.textInfo;

            if(inicio > textInfo.characterCount)
            {
                return;
            }

            final = Mathf.Min(final, textInfo.characterCount);

            var time = Time.time; // Armazena o valor de Time.time uma vez
            // Loop único para atualizar os vértices de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                var xOffset = 0f;

                // Loop para atualizar os quatro vértices de cada caractere
                for (int j = 0; j < 4; j++)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    xOffset = Mathf.Sin(time * freq + orig.x * 0.01f) * amp;
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, xOffset, 0);
                }
            }
        }
        private static void ShakeEffectLetter(TextMeshProUGUI textComponent, float magnitude, int inicio, int final)
        {
            var textInfo = textComponent.textInfo;

            if (inicio > textInfo.characterCount)
            {
                return;
            }
            final = Mathf.Min(final, textInfo.characterCount);

            // Loop único para atualizar os vértices de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                float xOffset = Random.Range(-1f, 1f) * magnitude;
                float yOffset = Random.Range(-1f, 1f) * magnitude;

                // Loop para atualizar os quatro vértices de cada caractere
                int index = charInfo.vertexIndex;
                verts[charInfo.vertexIndex] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 1] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 2] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 3] = verts[index++] + new Vector3(xOffset, yOffset, 0);
            }
        }
        private static void ShakeEffectText(TextMeshProUGUI textComponent, float magnitude, int inicio, int final)
        {
            var textInfo = textComponent.textInfo;
            if (inicio > textInfo.characterCount)
            {
                return;
            }

            final = Mathf.Min(final, textInfo.characterCount);

            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;

            // Loop único para atualizar os vértices de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                // Loop para atualizar os quatro vértices de cada caractere
                int index = charInfo.vertexIndex;
                verts[charInfo.vertexIndex] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 1] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 2] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 3] = verts[index++] + new Vector3(xOffset, yOffset, 0);
            }
        }
        private static void ShakeEffectWord(TextMeshProUGUI textComponent, float magnitude, int inicio, int final)
        {
            //textComponent.ForceMeshUpdate();
            var textInfo = textComponent.textInfo;
            if (inicio > textInfo.characterCount)
            {
                return;
            }

            final = Mathf.Min(final, textInfo.characterCount);

            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;

            // Loop único para atualizar os vértices de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    xOffset = Random.Range(-1f, 1f) * magnitude;
                    yOffset = Random.Range(-1f, 1f) * magnitude;
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                int index = charInfo.vertexIndex;
                verts[charInfo.vertexIndex] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 1] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 2] = verts[index++] + new Vector3(xOffset, yOffset, 0);
                verts[charInfo.vertexIndex + 3] = verts[index++] + new Vector3(xOffset, yOffset, 0);
            }
        }

        private static float hueValue = 0.5f;
        //FIXME
        //Algumas vezes está alterando a cor da primeira letra. 
        private static void RainbowEffect(TextMeshProUGUI textComponent, float speed, int inicio, int final)
        {
            var textInfo = textComponent.textInfo;
            if (inicio < 0 || inicio > textInfo.characterCount)
            {
                return;
            }

            final = Mathf.Min(final, textInfo.characterCount);

            var time = Time.time;
            // Loop único para atualizar as cores de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible)
                {
                    continue;
                }
                int materialIndex = charInfo.materialReferenceIndex;

                Color32[] cores = textInfo.meshInfo[materialIndex].colors32;

                var verts = textInfo.meshInfo[materialIndex].vertices;
                for (int j = 0; j < 4; j++)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    hueValue = Mathf.Repeat(hueValue + speed * time * 10 + orig.x, 360) / 360;
                    Color32 newColor = Color.HSVToRGB(hueValue, 1, 1);
                    cores[charInfo.vertexIndex + j++] = newColor;
                    cores[charInfo.vertexIndex + j] = newColor;
                }
            }
        }
        private static void JumpEffect(TextMeshProUGUI textComponent, float freq, float amp, int inicio, int final)
        {
            var textInfo = textComponent.textInfo;

            if (inicio > textInfo.characterCount)
            {
                return;
            }

            final = Mathf.Min(final, textInfo.characterCount);

            var time = Time.time; // Armazena o valor de Time.time uma vez


            // Loop único para atualizar os vértices de todos os caracteres
            for (int i = inicio; i < final; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
                var xOffset = 0f;
                var orig = verts[charInfo.vertexIndex];
                float x = time * freq - (i - inicio) * 1f;
                xOffset = Mathf.Sin(x) * amp;
                if (xOffset < 0)
                    xOffset = 0;

                // Loop para atualizar os quatro vértices de cada caractere
                for (int j = 0; j < 4; j++)
                {
                    orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, xOffset, 0);
                }
            }

        }

        private static bool efeitoExiste(string efeito)
        {
            foreach(string s in efeitosReais)
            {
                if(efeito == s)
                {
                    return true;
                }
            }
            return false;
        }
        public static TextFormat FormataTexto(string newText)
        {
            TextFormat retorno = new TextFormat();
            bool readingInside = false; 
            int realStringIndex = 0;

            foreach(char c in newText)
            {
                if(c == '<')
                {
                    Debug.Log("Começou a ler");
                    readingInside = true;
                    retorno.listaEfeitos[retorno.listaEfeitosIndex] = new EffectLabel("", realStringIndex, 0);
                    continue;

                } else if (c == '>')
                {
                    if (readingInside)
                    {
                        readingInside = false;
                        if (!efeitoExiste(retorno.listaEfeitos[retorno.listaEfeitosIndex].type))
                        {
                            retorno.text += "<" + retorno.listaEfeitos[retorno.listaEfeitosIndex].type + ">";
                        }
                    } else
                    {
                        retorno.listaEfeitos[retorno.listaEfeitosIndex].endIndex = realStringIndex;
                        retorno.listaEfeitosIndex++;
                    }
                    continue;
                }
                if (readingInside)
                {
                    retorno.listaEfeitos[retorno.listaEfeitosIndex].type += c;
                    continue;
                }
                retorno.text += c;
                realStringIndex++;
            }
            return retorno;
        }
        public static IEnumerator ExeEffect(TextMeshProUGUI textComponent, TextFormat input, float time)
        {
            while (true)
            {
                AtualizaEfeitos(textComponent, input);
                yield return new WaitForSeconds(time);
            }
        }
        public static void AtualizaEfeitos(TextMeshProUGUI textComponent, TextFormat input)
        {
            textComponent.ForceMeshUpdate();
            for (int i = 0; i < input.listaEfeitosIndex; i++)
            {
                switch (input.listaEfeitos[i].type)
                {
                    case "w":
                        WoobleEffectText(textComponent, 10, 2, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "st":
                        ShakeEffectText(textComponent, 10, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "sw":
                        ShakeEffectWord(textComponent, 10, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "sl":
                        ShakeEffectLetter(textComponent, 8, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "rainbow":
                        RainbowEffect(textComponent, 40, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "jump":
                        JumpEffect(textComponent, 10, 10, input.listaEfeitos[i].startIndex, input.listaEfeitos[i].endIndex);
                        break;
                    case "wait":
                        break;
                    default:
                        Debug.LogError("Effect type doesn't exist. Check if it's correctly typed");
                        break;
                }
            }
            UpdateMeshGeometry(textComponent);
        }
    }
}