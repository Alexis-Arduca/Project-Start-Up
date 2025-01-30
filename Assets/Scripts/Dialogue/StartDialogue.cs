using System;
using UnityEngine;
using Yarn.Unity;

public class StartDialogue : MonoBehaviour
{
    private bool firstTime = true;

    [Header("Dialogue")]
    public DialogueRunner dialogueRunner;
    public Canvas dialogueCanvas;
    
    private void Start()
    {
        dialogueCanvas.enabled = true;
    }

    private void Update()
    {
        if (GeneratorBehavior.isOn && firstTime)
        {
            firstTime = false;
        }
    }

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
        if (!dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.StartDialogue("Demo");
        }
        else
        {
            dialogueCanvas.enabled = true;
        }
    }
    
    private void RadioOff()
    {
        dialogueCanvas.enabled = false;
    }

    private void OnCollisionExit(Collision other)
    {
        dialogueCanvas.enabled = false;
    }
}
