using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLink : MonoBehaviour
{
    public bool baseColor = false;
    public bool isColored;
    public int myColor;
    public int currentColor;
    public int drawingColor;
    private RectTransform rectTransform;
    private bool isClickingOnElement = false;
    public float comparisonThreshold = 0.1f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        GameEventsManager.instance.colorLinkEvents.onColorSet += ColorSet;
        GameEventsManager.instance.colorLinkEvents.onResetColor += ResetColor;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.colorLinkEvents.onColorSet -= ColorSet;
        GameEventsManager.instance.colorLinkEvents.onResetColor -= ResetColor;
    }

    public void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (baseColor == true)
        {
            if (Input.GetMouseButtonDown(0) &&
                RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, null))
            {
                currentColor = myColor;
                isClickingOnElement = true;
                GameEventsManager.instance.colorLinkEvents.OnColorSet(myColor);
            }

            if (Input.GetMouseButton(0) && isClickingOnElement)
            {
                GameEventsManager.instance.colorLinkEvents.OnColorSet(currentColor);
            }

            if (Input.GetMouseButtonUp(0) && isClickingOnElement)
            {
                isClickingOnElement = false;
                GameEventsManager.instance.colorLinkEvents.OnColorMouseRelease();
            }
        }
        else
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, null))
            {
                ColorBlackTiles();
            }
        }
    }

    public void ColorBlackTiles()
    {
        if (isColored == false && Input.GetMouseButton(0)) {
            if (drawingColor == 1 && CheckCompatibility(drawingColor)) {
                gameObject.GetComponent<RawImage>().color = new Color(255, 0, 0);
                gameObject.GetComponent<ColorLink>().SetCurrentColor(drawingColor); 
                isColored = true;
            } else if (drawingColor == 2 && CheckCompatibility(drawingColor)) {
                gameObject.GetComponent<RawImage>().color = new Color(0, 0, 255);
                gameObject.GetComponent<ColorLink>().SetCurrentColor(drawingColor); 
                isColored = true;
            } else if (drawingColor == 3 && CheckCompatibility(drawingColor)) {
                gameObject.GetComponent<RawImage>().color = new Color(255, 255, 0);
                gameObject.GetComponent<ColorLink>().SetCurrentColor(drawingColor); 
                isColored = true;
            } else if (drawingColor == 4 && CheckCompatibility(drawingColor)) {
                gameObject.GetComponent<RawImage>().color = new Color(0, 255, 0);
                gameObject.GetComponent<ColorLink>().SetCurrentColor(drawingColor); 
                isColored = true;
            } else {
                Debug.Log("No color selected or there is no same color close");
            }
        }
    }

    private bool CheckCompatibility(int drawingColor)
    {
        Vector2Int[] directions = new Vector2Int[] {
            new Vector2Int(-1, 0),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(0, 1)
        };

        GameObject gridContainer = GameEventsManager.instance.GridContainer;
        Transform[] gridElements = gridContainer.GetComponentsInChildren<Transform>();
        Vector3 thisPosition = transform.position;
        int x = 0;
        int y = 0;

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

                        if (Vector3.Distance(gridElements[index].transform.position, thisPosition) < comparisonThreshold)
                        {
                            x = i;
                            y = j;
                        }
                        index++;
                    }
                }
            }

            foreach (var dir in directions)
            {
                int newI = x + dir.x;
                int newJ = y + dir.y;
        
                if (newI >= 0 && newI < 5 && newJ >= 0 && newJ < 5)
                {
                    if (drawingColor == gridArray[newI, newJ].GetComponent<ColorLink>().GetCurrentColor())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void ResetColor()
    {
        if (gameObject.activeSelf) {
            RawImage rawImage = gameObject.GetComponent<RawImage>();
            if (rawImage != null && myColor == 0) {
                rawImage.color = new Color(0, 0, 0);
            }
        }
        isColored = false;
    }

    /*
    /// [===] Getter and Setters [===]
    /// - 1 = red
    /// - 2 = blue
    /// - 3 = yellow
    /// - 4 = green
    */
    private void ColorSet(int color)
    {
        drawingColor = color;
    }

    public bool GetIsBaseColor()
    {
        return baseColor;
    }

    public int GetMyColor()
    {
        return myColor;
    }

    public void SetCurrentColor(int color)
    {
        currentColor = color;
    }

    public int GetCurrentColor()
    {
        return currentColor;
    }
}
