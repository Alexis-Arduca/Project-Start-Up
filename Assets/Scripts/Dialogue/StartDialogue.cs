using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Editor;

public class StartDialogue : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            FindObjectOfType<DialogueRunner>().StartDialogue("Start");
    }

    private void OnCollisionExit(Collision other)
    {
        FindObjectOfType<DialogueRunner>().Stop();
    }
}
