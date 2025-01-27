using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class GeneratorBehavior : MonoBehaviour
{
    public static bool isOn;
    
    private Coroutine fuelConsumptionCoroutine;
    public GameObject dialogueSystem;

    [YarnFunction("printFuelLevel")]
    public static int PrintFuelLevel()
    {
        return FuelConsumption.fuelLevel;
    }

    private void Update()
    {
        // Check if the generator is on while the fuel level is 0
        if (isOn && FuelConsumption.fuelLevel <= 0)
        {
            isOn = false;
        }
        
        if (isOn && fuelConsumptionCoroutine == null)
        {
            fuelConsumptionCoroutine = StartCoroutine(FuelConsumption.ConsumeFuel());
        }
        else if (!isOn && fuelConsumptionCoroutine != null)
        {
            StopCoroutine(fuelConsumptionCoroutine);
            fuelConsumptionCoroutine = null;
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
