using Assets.Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameMenu : MonoBehaviour
{
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
                CursorLocker.LockCursor();
                GameMenuCanvas.SetActive(false);
            }
            else
            {
                CursorLocker.UnlockCursor();
                GameMenuCanvas.SetActive(true);
            }
        }
    }
    public void OnContinue()
    {
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
