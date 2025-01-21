using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public MiscEvents miscEvents;
    public PlayerEvents playerEvents;

    public GameObject ColorLink;
    public GameObject GridContainer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

        // initialize all events
        miscEvents = new MiscEvents();
        playerEvents = new PlayerEvents();
    }
}