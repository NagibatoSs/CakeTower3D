using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] TowerManager towerManager;
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<TowerManager>().FromInstance(towerManager).AsSingle();
        Container.Bind<IPoolSelector>().To<SequencePoolSelector>().AsSingle();

    }
}
