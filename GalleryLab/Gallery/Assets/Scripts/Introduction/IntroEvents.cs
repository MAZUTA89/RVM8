using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntroEvents
{
    public static event Action OnReachedIntroPointEvent;

    public static event Action OnEndIntroEvent;

    public static void InvokeOnReachedIntroPositionEvent()
    {
        OnReachedIntroPointEvent?.Invoke();
    }

    public static void InvokeOnEndIntroEvent()
    {
        OnEndIntroEvent?.Invoke();
    }
}
