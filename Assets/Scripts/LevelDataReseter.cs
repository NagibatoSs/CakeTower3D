using UnityEngine;
using Zenject;

public class LevelDataReseter : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    [SerializeField] PointsManager pointsManager;
    [SerializeField] TowerHeightManager heightManager;
    [SerializeField] Timer timer;
    public void CleanData()
    {
        towerManager.ResetTower();
        pointsManager.ResetCoinsCount();
        heightManager.ResetHeight();
        timer.PauseTimer();
    }
}
