using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueScript;
    bool playerDetected;

   private void OnTriggerEnter2D(Collider2D collision)

    {
        if (!playerDetected && collision.CompareTag("Player"))
        {
            playerDetected = true;
            dialogueScript.ToggleWindow(playerDetected);
            dialogueScript.StartDialouge();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
            dialogueScript.ToggleWindow(playerDetected);
            dialogueScript.EndDialouge();
        }
    }

}
