using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagePopup : MonoBehaviour
{
    public string popUpMessage;
    private GameObject objectPopUp;
    private TMPro.TMP_Text messagePopUp;
    public bool popUpShow;

    // Start is called before the first frame update
    void Start()
    {
        popUpShow = false;
        objectPopUp = GameObject.Find("MessagePopUp");
        messagePopUp = objectPopUp.GetComponent<TMP_Text>();
        // GameEventsManager.instance.playerEvents.onActionChange += HidePopUp;
    }

    private void OnDisable()
    {
        // GameEventsManager.instance.playerEvents.onActionChange -= HidePopUp;
    }

    public void PopUpState(bool state)
    {
        popUpShow = state;
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
