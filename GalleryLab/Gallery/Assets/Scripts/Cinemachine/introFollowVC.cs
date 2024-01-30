using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introFollowVC : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera MenuCamera;
    CinemachineVirtualCamera vc;
    private void OnEnable()
    {
        IntroEvents.OnReachedIntroPointEvent += OnPLayerStopWalk;
    }
    private void OnDisable()
    {
        IntroEvents.OnReachedIntroPointEvent += OnPLayerStopWalk;
    }
    // Start is called before the first frame update
    void Start()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        CameraSwitcher.Regiser(vc);
        CameraSwitcher.Activate(vc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPLayerStopWalk()
    {
        CameraSwitcher.Activate(MenuCamera);
    }
}
