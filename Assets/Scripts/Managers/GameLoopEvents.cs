using System;
using UnityEngine;

public class GameLoopEvents
{
    public event Action onStepEnd;
    public void OnStepEnd()
    {
        if (onStepEnd != null)
        {
            onStepEnd();
        }
    }

    public event Action onTutorialStart;
    public void OnTutorialStart()
    {
        if (onTutorialStart != null)
        {
            onTutorialStart();
        }
    }

    public event Action onTutorialContinue;
    public void OnTutorialContinue()
    {
        if (onTutorialContinue != null)
        {
            onTutorialContinue();
        }
    }

    public event Action onTutorialEnd;
    public void OnTutorialEnd()
    {
        if (onTutorialEnd != null)
        {
            onTutorialEnd();
        }
    }

    public event Action onColorLinkEnd;
    public void OnColorLinkEnd()
    {
        if (onColorLinkEnd != null)
        {
            onColorLinkEnd();
        }
    }
    
    public event Action onColorTileEnd;
    public void OnColorTileEnd()
    {
        if (onColorTileEnd != null)
        {
            onColorTileEnd();
        }
    }

    public event Action onRadioEnd;
    public void OnRadioEnd()
    {
        if (onRadioEnd != null)
        {
            onRadioEnd();
        }
    }

    public event Action onPeopleDie;
    public void OnPeopleDie()
    {
        if (onPeopleDie != null)
        {
            onPeopleDie();
        }
    }

    public event Action onPeopleSave;
    public void OnPeopleSave()
    {
        if (onPeopleSave != null)
        {
            onPeopleSave();
        }
    }
}
