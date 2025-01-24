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
    
    [YarnFunction("printFuelLevel")]
    public static int PrintFuelLevel()
    {
        return FuelConsumption.fuelLevel;
    }

    private void Update()
    {
        if (isOn && FuelConsumption.fuelLevel <= 0)
        {
            isOn = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = !isOn;
            if (isOn)
            {
                dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("GeneratorOn");
            }
            else
            {
                dialogueSystem.GetComponent<DialogueRunner>().StartDialogue("GeneratorOff");
            }
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        dialogueSystem.GetComponent<DialogueRunner>().Stop();
    }
}
