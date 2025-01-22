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
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            radioAudioSource.Stop();
            radioAudioSource.clip = radioAnswer;
            radioAudioSource.Play();
            FindObjectOfType<DialogueRunner>().StartDialogue("Start");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        radioAudioSource.Stop();
        FindObjectOfType<DialogueRunner>().Stop();
    }
}
