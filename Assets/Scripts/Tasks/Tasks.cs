using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TasksInfo", menuName = "Tasks/TasksInfo", order = 1)]
public class Tasks : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; }

    [Header("General")]
    public string taskName;
    public string description;

    [Header("Mini-Game Settings")]
    public GameObject taskPrefab;
    public bool isCompleted;

    public void InitializeTask()
    {
        isCompleted = false;
        Debug.Log($"Task {taskName} initialized.");
    }

    public void StartTask()
    {
        Debug.Log($"Task {taskName} started!");
        if (taskPrefab != null)
        {
            GameObject taskInstance = Instantiate(taskPrefab);
        }
    }

    public void CompleteTask()
    {
        isCompleted = true;
        Debug.Log($"Task {taskName} completed!");
    }
}
