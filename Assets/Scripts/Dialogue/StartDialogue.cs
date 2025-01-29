using System;
using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(AudioSource))]
public class StartDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public Canvas dialogueCanvas;
    private bool firstTime = true;
    
    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip radioCallingSound;
    public AudioClip radioAnswerSound;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogueCanvas.enabled = true;
    }

    private void Update()
    {
        if (GeneratorBehavior.isOn && firstTime)
        {
            audioSource.PlayOneShot(radioCallingSound);
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
        audioSource.Stop();
        audioSource.PlayOneShot(radioAnswerSound);
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
        audioSource.Stop();
        dialogueCanvas.enabled = false;
    }
}
