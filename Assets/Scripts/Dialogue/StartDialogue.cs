using UnityEngine;
using Yarn.Unity;

public class StartDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public Canvas dialogueCanvas;
    
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
            Debug.Log("Resume dialogue");
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
