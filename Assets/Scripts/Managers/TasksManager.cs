using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    public List<Tasks> miniGames;

    public void StartMiniGame(string taskId)
    {
        Tasks task = miniGames.Find(t => t.id == taskId);

        if (task != null)
        {
            task.InitializeTask();
            task.StartTask();
        }
        else
        {
            Debug.LogWarning($"Task with ID {taskId} not found!");
        }
    }

    public void CompleteMiniGame(string taskId)
    {
        Tasks task = miniGames.Find(t => t.id == taskId);

        if (task != null)
        {
            task.CompleteTask();
        }
    }
}
