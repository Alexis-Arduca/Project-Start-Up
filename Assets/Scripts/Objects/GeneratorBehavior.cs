using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class GeneratorBehavior : MonoBehaviour
{
    public static bool isOn = true;
    
    public GameObject dialogueSystem;

    public GameObject radio;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = !isOn;
            if (isOn)
            {
                dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("GeneratorOn");
                TurnOnRadio();
            }
            else
            {
                dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("GeneratorOff");
                TurnOffRadio();
            }
        }
    }
    
    private void TurnOnRadio()
    {
        radio.GetComponent<AudioSource>().Stop();
    }
    
    private void TurnOffRadio()
    {
        radio.GetComponent<AudioSource>().Stop();
    }
    
    private void OnCollisionExit(Collision other)
    {
        dialogueSystem.GetComponent<DialogueRunner>().Stop();
    }
}
