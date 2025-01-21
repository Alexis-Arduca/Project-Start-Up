using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerItem playerItem;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerItem = GetComponent<PlayerItem>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.HandleMovement();
        playerItem.HandleItemUsage();
    }
}
