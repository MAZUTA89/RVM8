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
    public bool IsSkip()
    {
        return _inputaActions.ActionsMap.IsSkip.WasPerformedThisFrame();
    }
    public bool IsEscape()
    {
        return _inputaActions.ActionsMap.Escape.WasPerformedThisFrame();
    }

    public void Lock()
    {
        _inputaActions.Disable();
    }
    public void Unlock()
    {
        _inputaActions.Enable();
    }
    public void LockMovement()
    {
        _inputaActions.ActionsMap.Movement.Disable();
    }
    public void UnlockMovement()
    {
        _inputaActions.ActionsMap.Movement.Enable();
    }

}
