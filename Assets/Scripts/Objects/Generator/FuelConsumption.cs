using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelConsumption : MonoBehaviour
{
    public static int fuelLevel = 100;
    
    public static IEnumerator ConsumeFuel()
    {
        while (fuelLevel > 0 && GeneratorBehavior.isOn)
        {
            yield return new WaitForSeconds(1);
            fuelLevel--;
        }
    }
}
