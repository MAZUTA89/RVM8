using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraTarget : MonoBehaviour
{
    private void Awake()
    {
        CameraTargetRef.FollowTarget = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        CameraSwitcher.Regiser(PlayerInstaller.PersonCameraRef);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
