using TMPro;
using UnityEngine;
using Zenject;

public class TowerHeightLoseUIManager : MonoBehaviour
{
    [Inject] LevelInitializer levelInitializer;
    [Inject] TowerHeightManager heightManager;
    [SerializeField] TMP_Text currentHeightText;
    [SerializeField] TMP_Text targetHeightText;

    private void OnEnable()
    {
        currentHeightText.text = heightManager.Height.ToString();
        targetHeightText.text = levelInitializer.TargetHeight.ToString();
    }
}
