using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class CountdownBlockController : MonoBehaviour
{
    [Inject] GameStateMachine gameStateMachine;
    [SerializeField] private float goDuration = 0.2f;
    [SerializeField] private int countdownValue = 3;
    [SerializeField] private string goText = "Вперед!";
    public Action OnCountdownFinished;
    public Action OnCountdownStarted;
    public Action<string> OnCountdownChanged;

    private void OnEnable()
    {
        gameStateMachine.OnStateChanged += OnStateChangedDelegate;
    }

    private void OnDisable()
    {
        gameStateMachine.OnStateChanged -= OnStateChangedDelegate;
    }

    private void OnStateChangedDelegate(GameState state)
    {
        if (state == GameState.Game)
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        OnCountdownStarted?.Invoke();
        StartCoroutine(Countdown());
    }


    private IEnumerator Countdown()
    {
        for(int i = countdownValue; i > 0; i--)
        {
            OnCountdownChanged?.Invoke(i.ToString());
            yield return new WaitForSeconds(1f);
        }
        OnCountdownChanged?.Invoke(goText);
        yield return new WaitForSeconds(goDuration);
        OnCountdownFinished?.Invoke();

    }

}
