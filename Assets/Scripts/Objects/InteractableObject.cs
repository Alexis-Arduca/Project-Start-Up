using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool taskStart = false;
    public Tasks task;
    private GameObject instantiatedTask;

    void Start()
    {
        GameEventsManager.instance.playerEvents.onActionChange += FinishTask;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onActionChange -= FinishTask;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.O) && taskStart == false)
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
        taskStart = !taskStart;
    }
}
