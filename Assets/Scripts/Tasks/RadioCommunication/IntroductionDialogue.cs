using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionDialogue : MonoBehaviour
{
    void Start()
    {
        GameEventsManager.instance.gameLoopEvents.OnRadioEnd();
        Debug.Log("Hey I'm Tutorial Guy");
        Destroy(gameObject);
    }
}
