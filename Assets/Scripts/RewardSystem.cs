using System;
using UnityEngine;
using Zenject;

public class RewardSystem : MonoBehaviour
{
    [Inject] GameStateMachine gameStateMachine;
    [Inject] PointsManager pointManager;
    [Inject] PlayerScriptableModel playerScriptableModel;
    public Action<int, int> OnReward;
    private void OnEnable()
    {
        gameStateMachine.OnWin += Reward;
    }
    private void OnDisable()
    {
        gameStateMachine.OnWin -= Reward;
    }

    private void Reward()
    {
        OnReward?.Invoke(playerScriptableModel.Model.Coin, pointManager.CoinsCount);
        RewardCoins();
        SetNewNextLevel();
        playerScriptableModel.Save();
    }
    private void RewardCoins()
    {
        playerScriptableModel.Model.Coin += pointManager.CoinsCount;
    }
    private void SetNewNextLevel()
    {
        playerScriptableModel.Model.LastLevelNumber++;
    }
}
