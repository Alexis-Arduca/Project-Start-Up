using UnityEngine;

public class TileGameManager : MonoBehaviour
{
    private GameObject tileGame;

    void Start()
    {
        tileGame = GameEventsManager.instance.tileGame;
        tileGame.SetActive(true);
    }

    void Update()
    {
        if (IsGameComplete())
        {
            Debug.Log("You won! All tiles are occupied or illuminated.");
            tileGame.SetActive(false);
            GameEventsManager.instance.gameLoopEvents.OnColorTileEnd();
            Destroy(gameObject);
        }
    }

    private bool IsGameComplete()
    {
        Tile[] allTiles = FindObjectsOfType<Tile>();

        foreach (Tile tile in allTiles)
        {
            if (!tile.IsOccupied() && !tile.IsIlluminated())
            {
                return false;
            }
        }

        return true;
    }

    public void ResetButton()
    {
        GameEventsManager.instance.tileGameEvents.OnResetGame();
    }
}
