using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsExit : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public string interactionKey = "r";
    public GameObject confirmationPanel;

    void Start()
    {
        confirmationPanel.SetActive(false);
    }
    
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            GameEventsManager.instance.playerEvents.OnActionChange();
            confirmationPanel.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
