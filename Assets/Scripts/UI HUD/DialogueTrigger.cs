using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    [SerializeField] private GameObject _pressCWindow;
    [SerializeField] private GameObject _kButton;
    [SerializeField] private GameObject _nextSentButton;
    [SerializeField] private int _finishDialIndex;

    private RequitementsBase _finishSc;
    bool playerDetected;

    private void Start()
    {
        _finishSc = GetComponent<RequitementsBase>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (!playerDetected && collision.CompareTag("Player")&& dialogueScript!=null)
        {
            playerDetected = true;
            StartDialogue();
           _nextSentButton.SetActive(playerDetected);
            
            if (_finishSc.HaveRequireItems)
            {
                _pressCWindow.SetActive(playerDetected&&!Application.isMobilePlatform);
                _kButton.SetActive(Application.isMobilePlatform);
            }
        }
        else if (!playerDetected && collision.CompareTag("Player")&&_finishSc.HaveRequireItems)
        {
             playerDetected = true;
            _pressCWindow.SetActive(playerDetected);
           _kButton.SetActive(Application.isMobilePlatform);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& dialogueScript!=null)
        {
            playerDetected = false;
           _nextSentButton.SetActive(playerDetected);
            dialogueScript.ToggleWindow(playerDetected);
            dialogueScript.EndDialogue();
                if(!Application.isMobilePlatform)
                 {_pressCWindow.SetActive(playerDetected);}
            if(Application.isMobilePlatform)
            {_kButton.SetActive(false);}

        }
    }


    private void StartDialogue()
    {
        dialogueScript.ToggleWindow(playerDetected);
        dialogueScript.StartDialogue();
    }
}
