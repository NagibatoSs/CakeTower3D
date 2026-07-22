using TMPro;
using UnityEngine;
using Zenject;

public class LevelUIHandler : MonoBehaviour
{
    [Inject] LevelInitializer levelInitializer;
    [SerializeField] TMP_Text currentLevelText;

    private void OnEnable()
    {
        levelInitializer.OnInitialize += UpdateUI;
    }
    private void OnDisable()
    {
        levelInitializer.OnInitialize -= UpdateUI;
    }

    private void UpdateUI()
    {
        currentLevelText.text = "Уровень " + levelInitializer.CurrentLevel.ToString();
    }
}
