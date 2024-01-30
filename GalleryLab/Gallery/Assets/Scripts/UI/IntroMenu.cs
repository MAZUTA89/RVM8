using Assets.Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    [SerializeField] GameObject IntroMenuCanvas;
    private void OnEnable()
    {
        IntroEvents.OnReachedIntroPointEvent += OnPlayerReachedIntroPoint;
    }
    private void OnDisable()
    {
        IntroEvents.OnReachedIntroPointEvent += OnPlayerReachedIntroPoint;
    }
    // Start is called before the first frame update
    void Start()
    {
        IntroMenuCanvas.SetActive(false);
        CursorLocker.LockCursor();
    }

    public void OnStart()
    {
        IntroMenuCanvas.SetActive(false);
        CameraSwitcher.Activate(PlayerInstaller.PersonCameraRef);
        IntroEvents.InvokeOnEndIntroEvent();
        CursorLocker.LockCursor();
    }
    public void OnWorkSpace()
    {
        Application.Quit();
    }
    public void OnPlayerReachedIntroPoint()
    {
        IntroMenuCanvas.SetActive(true);
        CursorLocker.UnlockCursor();
    }
}
