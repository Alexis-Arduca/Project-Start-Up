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
        Debug.Log("Oui");
        GameEventsManager.instance.gameLoopEvents.OnRadioEnd();

        dialogueRunner = GameEventsManager.instance.radioDialogueRunner;
        dialogueCanvas = GameEventsManager.instance.radioDialogueCanvas;
        
        dialogueCanvas.enabled = true;
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
