using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] PointsManager pointsManager;
    [SerializeField] TowerHeightManager heightManager;
    [SerializeField] LevelInitializer levelInitializer;
    [SerializeField] PlayerScriptableModel playerData;
    [SerializeField] SFXController sfxController;
    [SerializeField] LevelsScriptableModel levelaScriptableModel;
    [SerializeField] LevelDataReseter levelReseter;
    [SerializeField] RewardSystem rewardSystem;
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<TowerManager>().FromInstance(towerManager).AsSingle();
        Container.Bind<PointsManager>().FromInstance(pointsManager).AsSingle();
        Container.Bind<TowerHeightManager>().FromInstance(heightManager).AsSingle();
        Container.Bind<PlayerScriptableModel>().FromInstance(playerData).AsSingle();
        Container.Bind<LevelInitializer>().FromInstance(levelInitializer).AsSingle();
        Container.Bind<IPoolSelector>().To<SequencePoolSelector>().AsSingle();
        Container.Bind<SFXController>().FromInstance(sfxController).AsSingle();
        Container.Bind<LevelsScriptableModel>().FromInstance(levelaScriptableModel).AsSingle();
        Container.Bind<LevelDataReseter>().FromInstance(levelReseter).AsSingle();
        Container.Bind<RewardSystem>().FromInstance(rewardSystem).AsSingle();

    }
}
