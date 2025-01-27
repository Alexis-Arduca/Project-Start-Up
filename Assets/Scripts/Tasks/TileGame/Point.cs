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

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Point clicked: {gameObject.name}");

        if (eventData.button == PointerEventData.InputButton.Left)
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
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            RotateClockwise();
            this.gameObject.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        }
    }

    void SelectPoint()
    {
        Debug.Log($"Point selected: {gameObject.name}");
        selectedPoint = this;
        GetComponent<RawImage>().color = Color.green;
    }

    void DeselectPoint()
    {
        Debug.Log($"Point deselected: {gameObject.name}");
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

        IlluminateTiles(targetTile);

        DeselectPoint();
    }

    void IlluminateTiles(Tile startingTile)
    {
        Debug.Log($"Illuminating tiles from starting tile: {startingTile.gameObject.name}");

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
        Debug.Log($"Illuminating in direction {direction} from Tile {startingTile.gameObject.name}");
        Tile currentTile = startingTile;

        while (true)
        {
            Tile nextTile = currentTile.GetNeighborTile(direction);

            if (nextTile == null)
            {
                Debug.Log("No more tiles in this direction.");
                break;
            }

            if (nextTile.IsOccupied())
            {
                Debug.Log($"Tile {nextTile.gameObject.name} is occupied, skipping illumination.");
            }
            else
            {
                nextTile.Illuminate();
                Debug.Log($"Tile illuminated: {nextTile.gameObject.name}");
            }

            currentTile = nextTile;
        }
    }

    void RotateClockwise()
    {
        activeDirections = (Directions)(((int)activeDirections << 1) | ((int)activeDirections >> 3)) & (Directions.Left | Directions.Up | Directions.Right | Directions.Down);
        Debug.Log($"Rotated point {gameObject.name} to new directions: {activeDirections}");
    }
}
