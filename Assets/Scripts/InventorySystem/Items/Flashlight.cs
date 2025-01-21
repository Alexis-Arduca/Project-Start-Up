using UnityEngine;

[CreateAssetMenu(fileName = "Flashlight", menuName = "Inventory/Flashlight")]
public class Flashlight : Item
{
    public Flashlight() : base("Flashlight", null)
    {
    }

    public override void Use()
    {
        Debug.Log("Using Flashlight");
    }
}
