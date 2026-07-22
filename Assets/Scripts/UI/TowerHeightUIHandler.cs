using TMPro;
using UnityEngine;
using Zenject;

public class TowerHeightUIHandler : MonoBehaviour
{
    [Inject] TowerHeightManager heightManager;
    [Inject] LevelInitializer levelInitializer;
    [SerializeField] TMP_Text currentHeightText;
    [SerializeField] TMP_Text targetHeightText;

    private void OnEnable()
    {
        heightManager.OnHeightChanged += UpdateCurrentHeight;
        levelInitializer.OnInitialize += UpdateTargetHeight;
    }

    private void OnDisable()
    {
        heightManager.OnHeightChanged -= UpdateCurrentHeight;
        levelInitializer.OnInitialize -= UpdateTargetHeight;
    }

    private void UpdateCurrentHeight(int height)
    {
        currentHeightText.text = height.ToString();
    }
    private void UpdateTargetHeight()
    {
        targetHeightText.text = levelInitializer.TargetHeight.ToString();
    }
}
