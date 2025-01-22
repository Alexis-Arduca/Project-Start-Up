using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private bool playerAction = false;
    private PlayerMovement playerMovement;
    private PlayerItem playerItem;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerItem = GetComponent<PlayerItem>();
        GameEventsManager.instance.playerEvents.onActionChange += ChangeAction;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onActionChange -= ChangeAction;
    }

    private void ChangeAction()
    {
        playerAction = !playerAction;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAction) {
            playerMovement.HandleMovement(Camera.main.transform);
            playerItem.HandleItemUsage();
        }
    }

}
