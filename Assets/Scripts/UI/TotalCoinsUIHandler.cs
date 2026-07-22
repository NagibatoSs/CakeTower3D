using TMPro;
using UnityEngine;
using Zenject;

public class TotalCoinsUIHandler : MonoBehaviour
{
    [Inject] PlayerScriptableModel playerScriptableModel;
    [SerializeField] TMP_Text totalCoinsText;

    private void OnEnable()
    {
        playerScriptableModel.Model.OnCoinsChanged += SetCoins;
        totalCoinsText.text = playerScriptableModel.Model.Coin.ToString();
    }

    private void Start()
    {
        totalCoinsText.text = playerScriptableModel.Model.Coin.ToString();
    }
    private void SetCoins(int newCoinsCount)
    {
        totalCoinsText.text = newCoinsCount.ToString();
    }
}
