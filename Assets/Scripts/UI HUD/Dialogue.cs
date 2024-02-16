using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public int requiaredMoney = 100;
    public bool hasKey = false;
     public TMP_Text dialogueText;

    [SerializeField] private GameObject dialogueWindow;

    [SerializeField] private float writingSpeed;

    [SerializeField] private List<string> dialogues;

    //index of dialouge 
    private int index;
    private int charIndex;
    private bool dialogueShown = false;
    private bool waitNextSent;

    private void Awake()
    {
        ToggleWindow(false);
    }

    public void ToggleWindow(bool show)
    {
        dialogueWindow.SetActive(show);
    }

    public void StartDialouge()
    {
        if (dialogueShown)
            return;
        dialogueShown = true;
        
        ToggleWindow(true);
        index = 0;
        // Start whit first dialogue
        GetDialogue(0);

    }
    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        //clear dialouge component text
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());

    }
    public void EndDialouge()
    {
        dialogueShown = false;
        waitNextSent = false;
        StopAllCoroutines();
        ToggleWindow(false);

        // if Player have current key or money he can start new level
    }

    IEnumerator Writing()
    {
        string currentDialouge = dialogues[index];
        dialogueText.text += currentDialouge[charIndex];
        charIndex++;
        if (charIndex < currentDialouge.Length)
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
            index++;
            if (index < dialogues.Count)
            { GetDialogue(index); }
            else
            { EndDialouge(); }


        }
    }
}
