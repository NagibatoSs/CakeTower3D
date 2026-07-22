using System;
using UnityEngine;
using Zenject;

public class WinBlocksCondition : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    [Inject] GameStateMachine gameStateMachine;
    [Inject] LevelInitializer levelInitializer;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += CheckWin;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= CheckWin;
    }

    private void CheckWin(GameObject block)
    {
        if (towerManager.BlocksCount >= levelInitializer.TargetHeight)
        {
            gameStateMachine.SetWin();
        }
    }
}
