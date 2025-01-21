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
    public float timeLimit = 0f;
    public int score;
    public bool isCompleted;

    [Header("Rewards")]
    public int rewardPoints;
    public string rewardItem;

    public void InitializeTask()
    {
        isCompleted = false;
        score = 0;
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
        Debug.Log($"Task {taskName} completed! Reward: {rewardPoints} points, Item: {rewardItem}");
    }
}
