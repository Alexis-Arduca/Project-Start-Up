using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelConsumption : MonoBehaviour
{
    public static int fuelLevel = 100;

    private void Start()
    {
        // fuelLevel decreases by 1 every second using Coroutine
        StartCoroutine(ConsumeFuel());
    }
    
    private static IEnumerator ConsumeFuel()
    {
        while (fuelLevel > 0 && GeneratorBehavior.isOn)
        {
            yield return new WaitForSeconds(1);
            fuelLevel--;
        }
    }
}
