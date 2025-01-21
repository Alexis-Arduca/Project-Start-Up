using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public bool isEquipped;
    public int slotIndex;
    public Texture itemImage;

    public Item(string name, Texture image)
    {
        itemName = name;
        isEquipped = false;
        itemImage = image;
    }

    public virtual void Use()
    {
        Debug.Log($"{itemName} use !");
    }
}