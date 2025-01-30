using UnityEngine;
using Yarn.Unity;

public class GeneratorBehavior : MonoBehaviour
{
    public static bool isOn;
    private Renderer generatorRenderer;

    // Fuel consumption
    private Coroutine fuelConsumptionCoroutine;
    public Material[] generatorMaterial;

    [Header("Dialogue")]
    public DialogueRunner dialogueRunner;
    
    private void Start()
    {
        generatorRenderer = GetComponent<Renderer>();
    }
    
    [YarnFunction("printFuelLevel")]
    public static int PrintFuelLevel()
    {
        return FuelConsumption.fuelLevel;
    }

    private void Update()
    {
        switch (FuelConsumption.fuelLevel)
        {
            case > 75:
                generatorRenderer.material = generatorMaterial[0];
                break;
            case > 15:
                generatorRenderer.material = generatorMaterial[1];
                break;
            case > 0:
                generatorRenderer.material = generatorMaterial[2];
                break;
        }
        
        // Check if the generator is on while the fuel level is 0
        if (isOn && FuelConsumption.fuelLevel <= 0)
        {
            isOn = false;
        }
        
        if (isOn && fuelConsumptionCoroutine == null)
        {
            fuelConsumptionCoroutine = StartCoroutine(FuelConsumption.ConsumeFuel());
        }
        else if (!isOn && fuelConsumptionCoroutine != null)
        {
            StopCoroutine(fuelConsumptionCoroutine);
            fuelConsumptionCoroutine = null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FuelConsumption.fuelLevel > 0)
            {
                isOn = !isOn;
            }

            switch (isOn && FuelConsumption.fuelLevel > 0)
            {
                case true:
                    dialogueRunner.StartDialogue("GeneratorOn");
                    break;
                case false:
                    dialogueRunner.StartDialogue("GeneratorOff");
                    break;
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ResetFuelLevel(); 
            }
        }
    }

    private void ResetFuelLevel()
    {
        if (!isOn)
        {
            Debug.Log("Fuel level reset");
            FuelConsumption.fuelLevel = 100;
        }

    }
    
    private void OnCollisionExit(Collision other)
    {
        dialogueRunner.Stop();
    }
}
