using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] PlayerSO PlayerSO;
    public override void InstallBindings()
    {
        Container.Bind<InputService>().AsSingle();
        Container.Bind<InputLocker>().AsSingle();
        Container.BindInstances(PlayerSO);
        Container.Bind<Movement>().AsSingle();
        Container.Bind<RotateWithCamera>().AsSingle();
        Container.Bind<GameMenu>().AsSingle();
        Container.Bind<ArtItem>().FromComponentInHierarchy().AsTransient();
        Container.Bind<VCRotateExtention>().FromComponentInHierarchy().AsSingle();
    }
}
