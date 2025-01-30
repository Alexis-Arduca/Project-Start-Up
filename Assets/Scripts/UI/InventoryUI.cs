using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Inventory inventory;
    public RawImage[] itemImages;
    private int selectedIndex;

    void Start()
    {
        selectedIndex = 0;

        GameEventsManager gameManager = FindObjectOfType<GameEventsManager>();
        if (gameManager != null)
        {
            inventory = gameManager.GetInventory();
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }

        UpdateItemDisplay();
    }

    void Update()
    {
        if (inventoryPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                selectedIndex = 0;
                EquipSelectedItem();
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                selectedIndex = 1;
                EquipSelectedItem();
            }
        }
    }

    void UpdateItemDisplay()
    {
        for (int i = 0; i < itemImages.Length; i++) 
        {
            itemImages[i].gameObject.SetActive(false);
        }

        foreach (Item item in inventory.items)
        {
            int slotIndex = item.slotIndex;

            if (slotIndex >= 0 && slotIndex < itemImages.Length) 
            {
                itemImages[slotIndex].texture = item.itemImage;
                itemImages[slotIndex].color = item.isEquipped ? Color.yellow : Color.white;

                itemImages[slotIndex].gameObject.SetActive(true);
            }
        }
    }

    void EquipSelectedItem()
    {
        Item itemToEquip = null;

        foreach (Item item in inventory.items)
        {
            if (item.slotIndex == selectedIndex)
            {
                itemToEquip = item;
                break;
            }
        }

        if (itemToEquip != null)
        {
            if (inventory.GetEquippedItem() != itemToEquip) {
                inventory.UnequipItem(inventory.GetEquippedItem()?.itemName);
                inventory.EquipItem(itemToEquip.itemName);
            } else {
                inventory.UnequipItem(inventory.GetEquippedItem()?.itemName);
            }
        }

        UpdateItemDisplay();
    }
}