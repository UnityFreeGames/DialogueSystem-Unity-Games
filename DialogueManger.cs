using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManger : MonoBehaviour
{
    public TextMeshProUGUI  text_dialogue;
    public string[] lines;
    public float text_speed;

    private int index;

    void Start()
    {
        text_dialogue.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(text_dialogue.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();//stop typing dialogue and show all Messages
                text_dialogue.text = lines[index];
            }
        }
        
    }

    void StartDialogue()
    {
       index = 0;
       StartCoroutine(TypeLine(index));
    }

    IEnumerator TypeLine(int _index)
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            text_dialogue.text += c;
            yield return new WaitForSeconds(text_speed);           
        }        
       
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            index++;
            text_dialogue.text = string.Empty;
            StartCoroutine(TypeLine(index));
        }
        else
        {
            gameObject.SetActive(false);//hidden dialogue box
        }
    }

    
}
