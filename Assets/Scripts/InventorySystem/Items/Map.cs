using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Inventory/Map")]
public class Map : Item
{
    public Map() : base("Map", null)
    {
    }

    public override void Use()
    {
        Debug.Log("Using Map");
    }
}

/*
Just an example of the implementation for an item
*/