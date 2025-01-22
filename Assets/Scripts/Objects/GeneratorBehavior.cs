using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class GeneratorBehavior : MonoBehaviour
{
    private bool isOn = true;

    public GameObject radio;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = !isOn;
            if (isOn)
            {
                FindObjectOfType<DialogueRunner>().StartDialogue("GeneratorOn");
                TurnOnRadio();
            }
            else
            {
                FindObjectOfType<DialogueRunner>().StartDialogue("GeneratorOff");
                TurnOffRadio();
            }
        }
    }
    
    private void TurnOnRadio()
    {
        radio.SetActive(true);
        radio.GetComponent<AudioSource>().Stop();
    }
    
    private void TurnOffRadio()
    {
        radio.SetActive(false);
    }
    
    private void OnCollisionExit(Collision other)
    {
        FindObjectOfType<DialogueRunner>().Stop();
    }
}
