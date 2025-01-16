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
    
    public GameObject taskPrefab;

    public Tasks(string name)
    {
        taskName = name;
    }
}
