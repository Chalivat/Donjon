using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefilementDialogue : MonoBehaviour
{
    public Text text;

    public string[] dialogues;
    private int index;
    private int charIndex;
    public float speed;
    private float time;
    void Start()
    {
        
    }

    void Update()
    {
        TextScrolling();
        NextText();
    }

    void TextScrolling()
    {
        time += Time.deltaTime;

        if (charIndex < dialogues[index].Length)
        {
            if (time >= speed)
            {
                time = 0;
                text.text = String.Concat(text.text, dialogues[index][charIndex]);
                charIndex++;
            }
        }
    }

    void NextText()
    {
        if (Input.GetButtonDown("A"))
        {
            if (charIndex >= dialogues[index].Length)
            {
                index++;
                charIndex = 0;
                text.text = "";
            }
            else
            {
                text.text = dialogues[index];
                charIndex = dialogues[index].Length;
            }
        }
    }
}
