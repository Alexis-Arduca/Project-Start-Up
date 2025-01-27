using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Editor;

public class StartDialogue : MonoBehaviour
{
    public GameObject dialogueSystem;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GeneratorBehavior.isOn)
            {
                RadioOn();
            }
            else
            {
                RadioOff();
            }
        }
    }
    
    private void RadioOn()
    {
        if (!dialogueSystem.GetComponent<DialogueRunner>().IsDialogueRunning)
        {
            dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("Demo");
        }
        else
        {
            Debug.Log("Resume dialogue");
            dialogueSystem.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
    
    private void RadioOff()
    {
        dialogueSystem.GetComponentInChildren<Canvas>().enabled = false;
    }

    private void OnCollisionExit(Collision other)
    {
        dialogueSystem.GetComponentInChildren<Canvas>().enabled = false;
    }
}
