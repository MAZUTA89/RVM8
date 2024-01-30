using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using Cinemachine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] Transform Point;
    [SerializeField] CinemachineVirtualCamera PersonCamera;
    [SerializeField] CinemachineVirtualCamera IntroFollowVC;
    public static CinemachineVirtualCamera PersonCameraRef;

    public override void InstallBindings()
    {
        var playerToPoint = Container.InstantiatePrefabForComponent<PlayerToPoint>(PlayerPrefab, SpawnPoint.position, SpawnPoint.rotation, null);
        playerToPoint.SetPoint(Point);
        IntroFollowVC.LookAt = playerToPoint.transform;
        PersonCamera.Follow = CameraTargetRef.FollowTarget;
        InitPersonCameraRef();
        Container.Bind<IntroMenuVC>().FromComponentInHierarchy().AsSingle();
    }
    void InitPersonCameraRef()
    {
        PersonCameraRef = PersonCamera;
    }
}
