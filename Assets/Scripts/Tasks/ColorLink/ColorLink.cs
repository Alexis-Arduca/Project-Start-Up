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

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        GameEventsManager.instance.miscEvents.onColorSet += ColorSet;
        GameEventsManager.instance.miscEvents.onResetColor += ResetColor;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onColorSet -= ColorSet;
        GameEventsManager.instance.miscEvents.onResetColor -= ResetColor;
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
                GameEventsManager.instance.miscEvents.OnColorSet(myColor);
            }

            if (Input.GetMouseButton(0) && isClickingOnElement)
            {
                GameEventsManager.instance.miscEvents.OnColorSet(currentColor);
            }

            if (Input.GetMouseButtonUp(0) && isClickingOnElement)
            {
                isClickingOnElement = false;
                GameEventsManager.instance.miscEvents.OnColorMouseRelease();
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

    /*
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

    public void ColorBlackTiles()
    {
        if (isColored == false && Input.GetMouseButton(0)) {
            if (drawingColor == 1) {
                gameObject.GetComponent<RawImage>().color = new Color(255, 0, 0);
                gameObject.GetComponent<ColorLink>().SetCurrentColor(drawingColor); 
                isColored = true;
            } else if (drawingColor == 2) {
                gameObject.GetComponent<RawImage>().color = new Color(0, 0, 255);
                isColored = true;
            } else if (drawingColor == 3) {
                gameObject.GetComponent<RawImage>().color = new Color(255, 255, 0);
                isColored = true;
            } else if (drawingColor == 4) {
                gameObject.GetComponent<RawImage>().color = new Color(0, 255, 0);
                isColored = true;
            } else {
                Debug.Log("No color selected");
            }
        }
    }

    public void ResetColor()
    {
        isColored = false;
        if (myColor == 0) {
            gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0);
        } else if (myColor == 1) {
            gameObject.GetComponent<RawImage>().color = new Color(255, 0, 0);
        } else if (myColor == 2) {
            gameObject.GetComponent<RawImage>().color = new Color(0, 0, 255);
        } else if (myColor == 3) {
            gameObject.GetComponent<RawImage>().color = new Color(255, 255, 0);
        } else if (myColor == 4) {
            gameObject.GetComponent<RawImage>().color = new Color(0, 255, 0);
        }
    }
}
