using System;
using UnityEngine;
using Yarn.Unity;

public class DialogueCompleteHandler : MonoBehaviour
{
    public GameObject objectToAppear;

    public DialogueRunner dialogueRunner;

    private void Start()
    {
        if (dialogueRunner != null)
        {
            dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
        }

        // Initially hide the GameObject
        objectToAppear.SetActive(false);
    }

    private void OnDialogueComplete()
    {
        // Make the GameObject appear
        objectToAppear.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (objectToAppear.activeSelf)
        {
            objectToAppear.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (dialogueRunner != null)
        {
            dialogueRunner.onDialogueComplete.RemoveListener(OnDialogueComplete);
        }
    }
}