using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputLocker : MonoBehaviour
{
    InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    private void OnEnable()
    {
        IntroEvents.OnEndIntroEvent += OnEndIntro;
        ArtItem.OnInteractWithAudioDescriptionEvent += OnStartListenAudio;
        ArtItem.OnSkipAudioDescriptionEvent += OnSkipListenAdudio;
    }
    private void OnDisable()
    {
        IntroEvents.OnEndIntroEvent -= OnEndIntro;
        ArtItem.OnInteractWithAudioDescriptionEvent -= OnStartListenAudio;
        ArtItem.OnSkipAudioDescriptionEvent -= OnSkipListenAdudio;
    }
    // Start is called before the first frame update
    void Start()
    {
        _inputService.Lock();
    }

    public void OnEndIntro()
    {
        _inputService.Unlock();
    }
    public void OnStartListenAudio()
    {
        _inputService.LockMovement();
    }
    public void OnSkipListenAdudio()
    {
        _inputService.UnlockMovement();
    }
}
