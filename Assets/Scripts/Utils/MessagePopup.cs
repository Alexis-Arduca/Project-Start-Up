using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagePopup : MonoBehaviour
{
    public string popUpMessage;
    private GameObject objectPopUp;
    private TMPro.TMP_Text messagePopUp;
    private bool popUpShow = true;

    // Start is called before the first frame update
    void Start()
    {
        objectPopUp = GameObject.Find("MessagePopUp");
        messagePopUp = objectPopUp.GetComponent<TMP_Text>();
        GameEventsManager.instance.playerEvents.onActionChange += HidePopUp;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onActionChange -= HidePopUp;
    }

    private void HidePopUp()
    {
        Debug.Log("Enter Here: " + popUpShow);
        popUpShow = !popUpShow;
        Debug.Log("2: " + popUpShow);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectPopUp != null && popUpShow == true)
            {   
                messagePopUp.text = popUpMessage;

                objectPopUp.SetActive(true);
            } else {
                messagePopUp.text = "";

                objectPopUp.SetActive(false);
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
