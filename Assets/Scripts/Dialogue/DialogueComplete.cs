using UnityEngine;
using Yarn.Unity;

public class DialogueCompleteHandler : MonoBehaviour
{
    public static GameObject objectToAppear;

    private void Start()
    {
        objectToAppear = GameObject.FindGameObjectWithTag("Pinpoint");
        objectToAppear.SetActive(false);
    }
    
    [YarnCommand("appear")]
    public static void Appear()
    {
        // Make the GameObject appear
        objectToAppear.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (objectToAppear.activeSelf)
        {
            objectToAppear.SetActive(false);
        }
    }
}