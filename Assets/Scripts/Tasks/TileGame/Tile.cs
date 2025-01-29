using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private bool isOccupied = false;
    private bool isIlluminated = false;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        ResetColor();
        GameEventsManager.instance.tileGameEvents.onResetGame += ResetTile;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.tileGameEvents.onResetGame -= ResetTile;
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
        rawImage.color = occupied ? Color.cyan : Color.white;
    }

    public void Illuminate()
    {
        isIlluminated = true;
        rawImage.color = Color.cyan;
    }

    public bool IsIlluminated()
    {
        return isIlluminated;
    }

    public void ResetColor()
    {
        rawImage.color = isOccupied ? Color.red : Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Point.selectedPoint != null && !isOccupied)
        {
            Point.selectedPoint.MoveToTile(this);
            SetOccupied(true);
        }
    }

    public Tile GetNeighborTile(Vector2 direction)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 neighborPosition = rectTransform.position + new Vector3(direction.x, direction.y) * rectTransform.rect.width;

        Tile closestTile = null;
        float closestDistance = float.MaxValue;

        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            float distance = Vector3.Distance(tile.transform.position, neighborPosition);
            if (distance < closestDistance && distance < rectTransform.rect.width * 0.9f)
            {
                closestTile = tile;
                closestDistance = distance;
            }
        }

        if (closestTile != null)
            Debug.Log($"Neighbor found: {closestTile.gameObject.name}");

        return closestTile;
    }

    public void ResetTile()
    {
        isOccupied = false;
        isIlluminated = false;
        rawImage.color = Color.white;
    }
}
    