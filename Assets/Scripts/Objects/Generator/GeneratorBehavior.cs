using UnityEngine;
using Yarn.Unity;

[RequireComponent(typeof(AudioSource))]
public class GeneratorBehavior : MonoBehaviour
{
    private Coroutine fuelConsumptionCoroutine;
    private AudioSource audioSource;

    public static bool isOn;
    public DialogueRunner dialogueRunner;
    
    [Header("Audio")]
    public AudioClip generatorSwitchSound;
    public AudioClip generatorDownSound;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    [YarnFunction("printFuelLevel")]
    public static int PrintFuelLevel()
    {
        return FuelConsumption.fuelLevel;
    }

    private void Update()
    {
        // Check if the generator is on while the fuel level is 0
        if (isOn && FuelConsumption.fuelLevel <= 0)
        {
            isOn = false;
            audioSource.PlayOneShot(generatorDownSound);
        }
        
        if (isOn && fuelConsumptionCoroutine == null)
        {
            audioSource.PlayOneShot(generatorSwitchSound);
            fuelConsumptionCoroutine = StartCoroutine(FuelConsumption.ConsumeFuel());
        }
        else if (!isOn && fuelConsumptionCoroutine != null)
        {
            audioSource.PlayOneShot(generatorSwitchSound);
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
