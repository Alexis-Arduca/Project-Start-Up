using System;
using UnityEngine;

public class PlayerEvents
{
    public event Action onActionChange;
    public void OnActionChange()
    {
        if (onActionChange != null)
        {
            onActionChange();
        }
    }
}
