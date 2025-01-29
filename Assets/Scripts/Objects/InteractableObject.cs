using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool canInteract;
    private bool taskStart;
    private int isTutorial;
    public Tasks task;
    public int objectIndex;
    private GameObject instantiatedTask;

    void Start()
    {
        canInteract = false;
        taskStart = false;
        isTutorial = 0;

        GameEventsManager.instance.gameLoopEvents.onStepEnd += FinishTask;

        if (objectIndex == 0) {
            GameEventsManager.instance.gameLoopEvents.onColorLinkEnd += FinishTask;
        } else if (objectIndex == 1) {
            GameEventsManager.instance.gameLoopEvents.onColorTileEnd += FinishTask;
        } else if (objectIndex == 2) {
            GameEventsManager.instance.gameLoopEvents.onRadioEnd += FinishTask;
        }
    }

    private void OnDisable()
    {
        GameEventsManager.instance.gameLoopEvents.onStepEnd -= FinishTask;

        GameEventsManager.instance.gameLoopEvents.onColorLinkEnd -= FinishTask;
        GameEventsManager.instance.gameLoopEvents.onColorTileEnd -= FinishTask;
        GameEventsManager.instance.gameLoopEvents.onRadioEnd -= FinishTask;
    }

    private void OnTriggerStay(Collider other)
    {
        if (canInteract == true && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.O) && taskStart == false)
        {
            if (task != null)
            {
                StartTask();
            }
            else
            {
                Debug.LogWarning("No task associated to this object.");
            }
        }
    }

    private void StartTask()
    {
        taskStart = !taskStart;
        if (task.taskPrefab != null)
        {
            instantiatedTask = Instantiate(task.taskPrefab);
            GameEventsManager.instance.playerEvents.OnActionChange();
        }
        else
        {
            Debug.LogWarning($"The task {task.taskName} has no prefab.");
        }
    }

    private void FinishTask()
    {
        Debug.Log("===[ Je suis entrer ici ]===");
        canInteract = !canInteract;
        GameEventsManager.instance.playerEvents.OnActionChange();

        Debug.Log(this.gameObject);
        if (isTutorial == 1) {
            Debug.Log("Tutorial 1 End");
            isTutorial = 0;
            GameEventsManager.instance.gameLoopEvents.OnTutorialStart();
        } else if (isTutorial == 2) {
            Debug.Log("Tutorial 2 End");
            isTutorial = 0;
            GameEventsManager.instance.gameLoopEvents.OnTutorialContinue();
        } else if (isTutorial == 3) {
            Debug.Log("Tutorial 3 End");
            isTutorial = 0;
            GameEventsManager.instance.gameLoopEvents.OnTutorialEnd();
        }
    }

    public void ChangeInteraction(bool state)
    {
        canInteract = state;
    }

    public void IsTutorial(int step)
    {
        isTutorial = step;
    }

    public void SetNewTask(Tasks newTask)
    {
        task = newTask;
        taskStart = false;
    }
}
