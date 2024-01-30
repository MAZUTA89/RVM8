using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IntroMenuVC : MonoBehaviour
{
    CinemachineVirtualCamera vc;
    
    // Start is called before the first frame update
    void Start()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        CameraSwitcher.Regiser(vc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnContinue()
    {
        
        Destroy(gameObject);
    }
}
