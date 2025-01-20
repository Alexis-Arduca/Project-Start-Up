using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLinkTask : MonoBehaviour
{
    private GameObject container;
    private GameObject gridContainer;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        container = GameEventsManager.instance.ColorLink;
        gridContainer = GameEventsManager.instance.GridContainer;

        if (container != null)
        {
            container.SetActive(true);
            Debug.Log("Container activé via GameManager !");
        }
        GameEventsManager.instance.miscEvents.onColorMouseRelease += GridCheck;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onColorMouseRelease -= GridCheck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GridCheck()
    {
        Transform[] gridElements = gridContainer.GetComponentsInChildren<Transform>();

        if (gridElements.Length >= 25)
        {
            Transform[,] gridArray = new Transform[5, 5];
            bool[,] visited = new bool[5, 5];

            int index = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (index < gridElements.Length)
                    {
                        gridArray[i, j] = gridElements[index];
                        index++;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (gridArray[i, j].GetComponent<ColorLink>().GetIsBaseColor() == true && !visited[i, j])
                    {
                        Debug.Log("Loop1");
                        if (GridCheckRec(i, j, gridArray, visited))
                        {
                            points += 1;
                        }
                    }
                }
            }
            Debug.Log("My Points: " + points);

            if (points == 4) {
                Debug.Log("Won");
                container.SetActive(false);
            } else {
                Debug.Log("Lose");
            }
        }
    }

    private bool GridCheckRec(int i, int j, Transform[,] gridArray, bool[,] visited)
    {
        ColorLink startImage = gridArray[i, j].GetComponent<ColorLink>();

        visited[i, j] = true;

        Vector2Int[] directions = new Vector2Int[] {
            new Vector2Int(-1, 0),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(0, 1)
        };

        foreach (var dir in directions)
        {
            int newI = i + dir.x;
            int newJ = j + dir.y;
    
            if (newI >= 0 && newI < 5 && newJ >= 0 && newJ < 5 && !visited[newI, newJ])
            {
                ColorLink newImage = gridArray[newI, newJ].GetComponent<ColorLink>();

                if (CompareColor(startImage, newImage))
                {
                    if (newImage.GetIsBaseColor() == true)
                    {
                        print(newI + newJ);
                        Debug.Log("Connection Create !");
                        return true;
                    }

                    if (GridCheckRec(newI, newJ, gridArray, visited))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool CompareColor(ColorLink color1, ColorLink color2)
    {
        return (color1.GetCurrentColor() == color2.GetCurrentColor());
    }


    public void ResetButton()
    {
        points = 0;
        GameEventsManager.instance.miscEvents.OnResetColor();
    }
}
