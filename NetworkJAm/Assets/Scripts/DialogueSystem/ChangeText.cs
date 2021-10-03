using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text texto;
    [TextArea(3,8)]
    public List<string> textos;
    private void Start()
    {
    
    }
    public void ChangeTexto(int idTexto)
    {
        texto.text = textos[idTexto].ToString();
    }
}
