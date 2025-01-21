using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Editor;

public class StartDialogue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FindObjectOfType<DialogueRunner>().StartDialogue("Start");
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueRunner>().Stop();
    }
}
