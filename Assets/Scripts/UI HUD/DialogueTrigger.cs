using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private GameObject _pressCWindow;
    [SerializeField] private int _finishDialIndex;

    private Finish _finishSc;
    bool playerDetected;

    private void Start()
    {
        _finishSc = FindAnyObjectByType<Finish>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (!playerDetected && collision.CompareTag("Player"))
        {
            playerDetected = true;
            dialogueScript.ToggleWindow(playerDetected);
             dialogueScript.StartDialogue();
            
            if (_finishSc.levelCompleted)
            {
                _pressCWindow.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
            dialogueScript.ToggleWindow(playerDetected);
            dialogueScript.EndDialogue();
        }
    }


    private void StartDialogue()
    {
        dialogueScript.ToggleWindow(playerDetected);
        dialogueScript.StartDialogue();
    }
}
