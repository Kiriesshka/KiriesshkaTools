using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextOutTypeA : MonoBehaviour
{
    public TMP_Text tmp;
    public string textToShow;
    public float timeToSymbol;
    private int timer;
    public void PushText(string a)
    {
        timer = 0;
        tmp.text = "";
        textToShow = a;
    }
    private void Update()
    {
        timer+=Time.deltaTime;
        if (timer > timeToSymbol)
        {
            timer = 0;
            if (tmp.text != textToShow)
            {
                tmp.text += textToShow[tmp.text.Length];
            }
        }
        

    }
}
