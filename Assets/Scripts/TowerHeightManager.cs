using System;
using UnityEngine;
using Zenject;

public class TowerHeightManager : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    public event Action<int> OnHeightChanged;
    private int height = 0;
    public int Height => height;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += EncreaseHeight;
        towerManager.OnCrunch += DecreaseHeight; 
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= EncreaseHeight;
        towerManager.OnCrunch -= DecreaseHeight;
    }

    public void ResetHeight()
    {
        height = 0;
        OnHeightChanged?.Invoke(height);
    }
    private void EncreaseHeight(GameObject block)
    {
        height++;
        OnHeightChanged?.Invoke(height);
    }
    private void DecreaseHeight(GameObject block)
    {
        height--;
        OnHeightChanged?.Invoke(height);
    }
}
