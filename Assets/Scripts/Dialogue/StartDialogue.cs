using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Editor;

public class StartDialogue : MonoBehaviour
{
    public AudioSource radioAudioSource;
    public AudioClip radioAnswer;
    public GameObject dialogueSystem;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            radioAudioSource.Stop();
            radioAudioSource.clip = radioAnswer;
            radioAudioSource.Play();
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
            dialogueSystem.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
    
    private void RadioOff()
    {
        radioAudioSource.Stop();
        dialogueSystem.GetComponent<DialogueRunner>().Stop();
        dialogueSystem.GetComponentInChildren<Canvas>().enabled = false;
    }

    private void OnCollisionExit(Collision other)
    {
        radioAudioSource.Stop();
        dialogueSystem.GetComponentInChildren<Canvas>().enabled = false;
    }
}
