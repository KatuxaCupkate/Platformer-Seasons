using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private GameObject _pressCWindow;
    [SerializeField] private int _finishDialIndex;

    private RequitementsBase _finishSc;
    bool playerDetected;

    private void Start()
    {
        _finishSc = GetComponent<RequitementsBase>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (!playerDetected && collision.CompareTag("Player"))
        {
            playerDetected = true;
           StartDialogue();
            
            if (_finishSc.HaveRequireItems)
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
