using TMPro;
using UnityEngine;
using Zenject;

public class PointsUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text pointsValueText;
    [Inject] PointsManager pointsManager;

    private void OnEnable()
    {
        pointsManager.OnCoinsChanged += AddPoint;
    }
    private void OnDisable()
    {
        pointsManager.OnCoinsChanged -= AddPoint;
    }
    private void AddPoint(int pointsCount)
    {
        pointsValueText.text = pointsCount.ToString();
    }
}
