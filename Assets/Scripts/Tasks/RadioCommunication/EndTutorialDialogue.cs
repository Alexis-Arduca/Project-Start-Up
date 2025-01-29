using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorialDialogue : MonoBehaviour
{
    void Start()
    {
        GameEventsManager.instance.gameLoopEvents.OnRadioEnd();
        Debug.Log("End of Tutorial");
        Destroy(gameObject);
    }
}
