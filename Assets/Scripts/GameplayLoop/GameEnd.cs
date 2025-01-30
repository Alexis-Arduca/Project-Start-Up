using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    private int peopleSaved;
    private int peopleDied;
    public int maxDieToEnd;

    public TMPro.TMP_Text peopleSavedText;
    public TMPro.TMP_Text peopleDiedText;

    void Start()
    {
        peopleDied = 0;
        peopleSaved = 0;

        peopleSavedText.text = $"People(s) save(s) : {peopleSaved}";
        peopleDiedText.text = $"People(s) deceased(s) : {peopleDied}";

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
        peopleDiedText.text = $"People(s) deceased(s) : {peopleDied}";
    }

    public void UpdatePeopleSaved()
    {
        peopleSaved += 1;
        peopleSavedText.text = $"People(s) save(s) : {peopleSaved}";
    }

    public int GetPeopleSaved()
    {
        return peopleSaved;
    }
}
