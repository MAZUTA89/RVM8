using Assets.Scripts.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameMenu : MonoBehaviour
{
    public static event Action OnPauseEvent;
    public static event Action OnContinueEvent;
    [SerializeField] GameObject GameMenuCanvas;
    [SerializeField] GameObject SkipButton;
    InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    private void OnEnable()
    {
        ArtItem.OnSkipAudioDescriptionEvent += OnSkipAudio;
        ArtItem.OnInteractWithAudioDescriptionEvent += OnInteractWithArtItem;
    }
    private void OnDisable()
    {
        ArtItem.OnSkipAudioDescriptionEvent -= OnSkipAudio;
        ArtItem.OnInteractWithAudioDescriptionEvent += OnInteractWithArtItem;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameMenuCanvas.SetActive(false);
        SkipButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputService.IsEscape())
        {
            if(GameMenuCanvas.activeSelf)
            {
                OnContinueEvent?.Invoke();
                CursorLocker.LockCursor();
                GameMenuCanvas.SetActive(false);
            }
            else
            {
                OnPauseEvent?.Invoke();
                CursorLocker.UnlockCursor();
                GameMenuCanvas.SetActive(true);
            }
        }
    }
    public void OnContinue()
    {
        OnContinueEvent?.Invoke();
        CursorLocker.LockCursor();
        GameMenuCanvas.SetActive(false);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnSkipAudio()
    {
        SkipButton.SetActive(false);
    }
    public void OnInteractWithArtItem()
    {
        SkipButton.SetActive(true);
    }
}
