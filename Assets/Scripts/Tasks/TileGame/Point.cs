using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[Flags]
public enum Directions
{
    None = 0,
    Up = 1,
    Right = 2,
    Down = 4,
    Left = 8
}

public class Point : MonoBehaviour, IPointerClickHandler
{
    public static Point selectedPoint = null;
    public Directions activeDirections;
    private RectTransform rectTransform;
    private bool placedPoint = false;
    private Vector3 basePosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        basePosition = gameObject.transform.position;

        GameEventsManager.instance.tileGameEvents.onResetGame += ResetPoint;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.tileGameEvents.onResetGame -= ResetPoint;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left  && placedPoint == false)
        {
            if (selectedPoint == null)
            {
                SelectPoint();
            }
            else if (selectedPoint == this)
            {
                DeselectPoint();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right && placedPoint == false)
        {
            RotateClockwise();
            this.gameObject.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        }
    }

    void SelectPoint()
    {
        selectedPoint = this;
        GetComponent<RawImage>().color = Color.green;
    }

    void DeselectPoint()
    {
        selectedPoint = null;
        GetComponent<RawImage>().color = Color.white;
    }

    public void MoveToTile(Tile targetTile)
    {
        if (targetTile.IsOccupied())
        {
            Debug.Log("Tile is already occupied!");
            return;
        }

        rectTransform.position = targetTile.GetComponent<RectTransform>().position;
        placedPoint = true;
    
        IlluminateTiles(targetTile);

        DeselectPoint();
    }

    void IlluminateTiles(Tile startingTile)
    {
        if (activeDirections.HasFlag(Directions.Up))
            IlluminateDirection(startingTile, Vector2.up);
        if (activeDirections.HasFlag(Directions.Down))
            IlluminateDirection(startingTile, Vector2.down);
        if (activeDirections.HasFlag(Directions.Left))
            IlluminateDirection(startingTile, Vector2.left);
        if (activeDirections.HasFlag(Directions.Right))
            IlluminateDirection(startingTile, Vector2.right);
    }

    void IlluminateDirection(Tile startingTile, Vector2 direction)
    {
        Tile currentTile = startingTile;

        while (true)
        {
            Tile nextTile = currentTile.GetNeighborTile(direction);

            if (nextTile == null)
            {
                break;
            }

            if (nextTile.IsOccupied())
            {
                Debug.Log($"Tile {nextTile.gameObject.name} is occupied, skipping illumination.");
            }
            else
            {
                nextTile.Illuminate();
            }

            currentTile = nextTile;
        }
    }

    void RotateClockwise()
    {
        activeDirections = (Directions)(((int)activeDirections << 1) | ((int)activeDirections >> 3)) & (Directions.Left | Directions.Up | Directions.Right | Directions.Down);
    }

    void ResetPoint()
    {
        gameObject.transform.position = basePosition;
        placedPoint = false;
    }
}
