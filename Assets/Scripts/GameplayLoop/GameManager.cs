using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject radio;
    public GameObject[] interactableObjects;
    public Tasks secondDialogue;
    private bool tutorial = true;
    private bool initTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.instance.gameLoopEvents.onTutorialStart += TutorialFirstTask;
        GameEventsManager.instance.gameLoopEvents.onTutorialContinue += LastTalkTutorial;
        GameEventsManager.instance.gameLoopEvents.onTutorialEnd += EndTutorial;
    }

    void OnDisable()
    {
        GameEventsManager.instance.gameLoopEvents.onTutorialStart -= TutorialFirstTask;
        GameEventsManager.instance.gameLoopEvents.onTutorialContinue -= LastTalkTutorial;
        GameEventsManager.instance.gameLoopEvents.onTutorialEnd -= EndTutorial;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial) {
            InitTutorial();
        } else {
            GameLoop();
        }
    }

    private void InitTutorial()
    {
        if (!initTutorial) {
            radio.GetComponent<InteractableObject>().ChangeInteraction(true);
            radio.GetComponent<InteractableObject>().IsTutorial(1);
            radio.GetComponent<MessagePopup>().PopUpState(true);

            initTutorial = true;
        }
    }

    private void TutorialFirstTask()
    {
        Debug.Log("FIRST TASK TUTORIAL");

        radio.GetComponent<MessagePopup>().PopUpState(false);
        radio.GetComponent<InteractableObject>().ChangeInteraction(false);

        if (interactableObjects.Length > 0)
        {
            GameObject randomObject = GetRandomGameObject();

            randomObject.GetComponent<InteractableObject>().ChangeInteraction(true);
            randomObject.GetComponent<InteractableObject>().IsTutorial(2);
            randomObject.GetComponent<MessagePopup>().PopUpState(true);
        }
    }

    private void LastTalkTutorial()
    {
        Debug.Log("SECOND TASK TUTORIAL");

        radio.GetComponent<InteractableObject>().SetNewTask(secondDialogue);
        radio.GetComponent<InteractableObject>().ChangeInteraction(true);
        radio.GetComponent<InteractableObject>().IsTutorial(3);
        radio.GetComponent<MessagePopup>().PopUpState(true);
    }

    private void EndTutorial()
    {
        Debug.Log("THE END");

        radio.GetComponent<MessagePopup>().PopUpState(false);
        tutorial = false;
    }

    private void GameLoop()
    {
        // Game Loop here
    }

    GameObject GetRandomGameObject()
    {
        int randomIndex = Random.Range(0, interactableObjects.Length);
        return interactableObjects[randomIndex];
    }
}
