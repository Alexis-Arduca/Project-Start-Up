using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Tasks task;
    private GameObject instantiatedTask;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.O))
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
}
