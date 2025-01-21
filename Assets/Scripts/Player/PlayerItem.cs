using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private GameEventsManager gameEventsManager;
    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        gameEventsManager = FindObjectOfType<GameEventsManager>();

        if (gameEventsManager != null)
        {
            inventory = gameEventsManager.GetInventory();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleItemUsage()
    {
        if (Input.GetMouseButtonDown(0)) {
            Item equippedItem = inventory.GetEquippedItem();

            if (equippedItem != null)
            {
                equippedItem.Use();
            }
            else
            {
                Debug.Log("No item equipped.");
            }
        }
    }
}
