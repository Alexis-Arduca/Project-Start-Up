using System;
using UnityEngine;
using Yarn.Unity;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public ColorLinkEvents colorLinkEvents;
    public PlayerEvents playerEvents;
    public TileGameEvents tileGameEvents;
    public GameLoopEvents gameLoopEvents;

    public GameObject ColorLink;
    public GameObject GridContainer;
    public GameObject spotLight;
    public GameObject tileGame;
    public Inventory inventory;
    
    [Header("Dialogue")]
    public DialogueRunner radioDialogueRunner;
    public Canvas radioDialogueCanvas;

    /* Temp */
    public Item flashlight;
    public Item map;

    private void Awake()
    {
        inventory = new Inventory();

        inventory.AddItem(flashlight);
        inventory.AddItem(map);

        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

        // initialize all events
        colorLinkEvents = new ColorLinkEvents();
        playerEvents = new PlayerEvents();
        tileGameEvents = new TileGameEvents();
        gameLoopEvents = new GameLoopEvents();
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}