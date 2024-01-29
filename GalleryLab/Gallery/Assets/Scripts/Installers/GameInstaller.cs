using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] PlayerSO PlayerSO;
    public override void InstallBindings()
    {
        Container.Bind<InputService>().AsSingle();
        Container.BindInstances(PlayerSO);
        Container.Bind<Movement>().AsSingle();
        Container.Bind<RotateWithCamera>().AsSingle();
    }
}
