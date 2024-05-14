using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;

    [SerializeField] private GameObject dialogueWindow;

    [SerializeField] private float writingSpeed;

    [SerializeField] private List<string> dialogues;
    [SerializeField] private int _finishDialIndex;
    private int _startDialIndex = 0;
    private RequitementsBase finishSc;

    //index of dialogue 
    private int index;
    private int charIndex;
    private bool dialogueShown = false;
    private bool firstEnter = false;
    private bool waitNextSent;

    public void Initialize(RequitementsBase finishSc)
    {
        ToggleWindow(false);
        this.finishSc = finishSc;
    }

    public void ToggleWindow(bool show)
    {
        dialogueWindow.SetActive(show);
        
    }

    public void StartDialogue()
    {
        if (dialogueShown)
            return;
        dialogueShown = true;

        ToggleWindow(true);
        if (finishSc.HaveRequireItems&&firstEnter)
       {  
            index = _finishDialIndex;
       } 
        else
           {
             firstEnter = true; 
             index = _startDialIndex;
           } 
        // Start with first dialogue
        GetDialogue(index);

    }
    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        //clear dialogue component text
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());

    }
    public void EndDialogue()
    {
        dialogueShown = false;
        waitNextSent = false;
        StopAllCoroutines();
        ToggleWindow(false);

    }

    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[charIndex];
        charIndex++;
        if (charIndex < currentDialogue.Length)
        {

            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());

        }
        else
        {
            waitNextSent = true;
        }

    }

    private void Update()
    {
        if (!dialogueShown)
            return;

        if (waitNextSent && Input.GetKeyDown(KeyCode.E))
        {
            waitNextSent = false;
            if (!finishSc.HaveRequireItems & index == _finishDialIndex-1)
                index = 0;
            else
                index++;

            if (index < dialogues.Count)
            { GetDialogue(index); }
            else 
            { EndDialogue(); }


        }
    }
}
