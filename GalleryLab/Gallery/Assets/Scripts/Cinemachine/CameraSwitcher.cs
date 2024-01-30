using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher
{
    const int c_ACTIVE_VC_PRIORITY = 7;
    const int c_OTHER_VC_PRIORITY = 0;

    static List<CinemachineVirtualCamera> _vcList;

    public static CinemachineVirtualCamera ActiveVirtualCamera { get; private set; }


    static CameraSwitcher()
    {
        _vcList = new List<CinemachineVirtualCamera>();
    }
    
    public static void Activate(CinemachineVirtualCamera vc)
    {
        ActivateVC(vc);

        DeactivateOtherVC();

        Debug.Log($"Activate {ActiveVirtualCamera}");
    }

    static void ActivateVC(CinemachineVirtualCamera vc)
    {
        ActiveVirtualCamera = vc;
        ActiveVirtualCamera.Priority = c_ACTIVE_VC_PRIORITY;
    }

    static void DeactivateOtherVC()
    {
        foreach (var camera in _vcList)
        {
            if (camera != ActiveVirtualCamera && camera.Priority != c_OTHER_VC_PRIORITY)
            {
                camera.Priority = c_OTHER_VC_PRIORITY;
            }
        }
    }
    
    public static void ActivateDefault(CinemachineVirtualCamera vc)
    {

    }
    public static void Regiser(CinemachineVirtualCamera vc)
    {
        vc.Priority = c_OTHER_VC_PRIORITY;
        _vcList.Add(vc);
    }

    public static void Unregister(CinemachineVirtualCamera vc)
    {
        _vcList.Remove(vc);
    }
}
