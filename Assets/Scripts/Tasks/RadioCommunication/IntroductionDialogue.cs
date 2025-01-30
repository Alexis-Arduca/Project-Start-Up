using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class IntroductionDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogueRunner dialogueRunner;
    public Canvas dialogueCanvas;
    
    void Start()
    {
        dialogueRunner = GameEventsManager.instance.radioDialogueRunner;
        dialogueCanvas = GameEventsManager.instance.radioDialogueCanvas;
        
        GameEventsManager.instance.gameLoopEvents.OnRadioEnd();
        dialogueCanvas.enabled = true;
        Debug.Log("Hey I'm Tutorial Guy");
        RadioOn();
        Destroy(gameObject);
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         if (GeneratorBehavior.isOn)
    //         {
    //             RadioOn();
    //         }
    //         else
    //         {
    //             RadioOff();
    //         }
    //     }
    // }
    
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
    
    // private void RadioOff()
    // {
    //     dialogueCanvas.enabled = false;
    // }
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     dialogueCanvas.enabled = false;
    // }
}
