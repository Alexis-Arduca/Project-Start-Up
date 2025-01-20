using System;
using UnityEngine;

public class MiscEvents
{
    public event Action<int> onColorSet;
    public void OnColorSet(int color)
    {
        if (onColorSet != null)
        {
            onColorSet(color);
        }
    }

    public event Action onColorMouseRelease;
    public void OnColorMouseRelease()
    {
        if (onColorMouseRelease != null)
        {
            onColorMouseRelease();
        }
    }

    public event Action onResetColor;
    public void OnResetColor()
    {
        if (onResetColor != null)
        {
            onResetColor();
        }
    }

    public event Action onColorConnect;
    public void OnColorConnect()
    {
        if (onColorConnect != null)
        {
            onColorConnect();
        }
    }
}
