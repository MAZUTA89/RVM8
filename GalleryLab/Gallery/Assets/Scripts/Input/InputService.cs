using System;
using UnityEngine;

public class InputService : IDisposable
{
    InputMap _inputaActions;

    public InputService()
    {
        _inputaActions = new InputMap();
        _inputaActions.Enable();
    }

    public void Dispose()
    {
        _inputaActions.Disable();
    }

    public Vector2 GetMouseDelta()
    {
        return _inputaActions.ActionsMap.MouseDelta.ReadValue<Vector2>();
    }

    public Vector2 GetMovement()
    {
        return _inputaActions.ActionsMap.Movement.ReadValue<Vector2>();
    }
    public bool IsInteract()
    {
        return _inputaActions.ActionsMap.Interact.WasPerformedThisFrame();
    }

    public void Lock()
    {
        _inputaActions.Disable();
    }
    public void Unlock()
    {
        _inputaActions.Enable();
    }

}
