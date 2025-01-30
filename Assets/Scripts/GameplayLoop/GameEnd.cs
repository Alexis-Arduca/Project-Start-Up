using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private int peopleSaved;
    private int peopleDied;
    public int maxDieToEnd;

    void Start()
    {
        peopleDied = 0;
        peopleSaved = 0;

        GameEventsManager.instance.gameLoopEvents.onPeopleDie += UpdatePeopleDied;
        GameEventsManager.instance.gameLoopEvents.onPeopleSave += UpdatePeopleSaved;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.gameLoopEvents.onPeopleDie -= UpdatePeopleDied;
        GameEventsManager.instance.gameLoopEvents.onPeopleSave -= UpdatePeopleSaved;
    }

    void Update()
    {
        if (peopleDied >= maxDieToEnd) {
            Debug.Log("Game End");
        }
    }

    public void UpdatePeopleDied()
    {
        peopleDied += 1;
    }

    public void UpdatePeopleSaved()
    {
        peopleSaved += 1;
    }

    public int GetPeopleSaved()
    {
        return peopleSaved;
    }
}
