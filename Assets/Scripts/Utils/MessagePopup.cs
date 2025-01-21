using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagePopup : MonoBehaviour
{
    public string popUpMessage;
    private GameObject objectPopUp;
    private TMPro.TMP_Text messagePopUp;

    // Start is called before the first frame update
    void Start()
    {
        objectPopUp = GameObject.Find("MessagePopUp");
        messagePopUp = objectPopUp.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectPopUp != null)
            {   
                messagePopUp.text = popUpMessage;

                objectPopUp.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectPopUp != null)
            {
                messagePopUp.text = "";

                objectPopUp.SetActive(false);
            }
        }
    }
}
