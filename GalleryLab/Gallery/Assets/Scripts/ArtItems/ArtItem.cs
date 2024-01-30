using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[RequireComponent(typeof(AudioSource))]
public class ArtItem : MonoBehaviour
{
    public static event Action OnSkipAudioDescriptionEvent;
    public static event Action OnInteractWithAudioDescriptionEvent;
    [SerializeField] CinemachineVirtualCamera ArtVC;
    AudioSource _audioSource;
    InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        CameraSwitcher.Regiser(ArtVC);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputService.IsSkip() && _audioSource.isPlaying)
        {
            _audioSource.Stop();
            OnSkipAudioDescriptionEvent?.Invoke();
            CameraSwitcher.Activate(PlayerInstaller.PersonCameraRef);
        }
    }
    public void Interact()
    {
        _audioSource.Play();
        CameraSwitcher.Activate(ArtVC);
        OnInteractWithAudioDescriptionEvent?.Invoke();
    }
}
