using System;
using UnityEngine;

public class TileGameEvents
{
    public event Action onResetGame;
    public void OnResetGame()
    {
        if (onResetGame != null)
        {
            onResetGame();
        }
    }
}
