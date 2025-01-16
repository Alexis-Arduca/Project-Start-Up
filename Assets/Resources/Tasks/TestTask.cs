using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTask : MonoBehaviour
{
    private GameObject minigamePanel;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            Transform panelTransform = canvas.transform.Find("TestPanel");

            if (panelTransform != null)
            {
                minigamePanel = panelTransform.gameObject;
                minigamePanel.SetActive(true);
            }
        }
    }
}
