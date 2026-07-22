using System;
using UnityEngine;

public class GameStateMachine
{
    public GameState CurrentState { get; private set; }
    public event Action<GameState> OnStateChanged;
    public event Action OnWin;
    public GameStateMachine()
    {
        CurrentState = GameState.Menu;
    }

    private void SetState(GameState state)
    {
        if (CurrentState == state)
            return;
        CurrentState = state;
        OnStateChanged?.Invoke(state);
    }

    public void SetMenu()
    {
        SetState(GameState.Menu);
    }

    public void SetGame()
    {
        SetState(GameState.Game);
    }

    public void SetLose()
    {
        SetState(GameState.Lose);
    }

    public void SetWin()
    {
        SetState(GameState.Win);
        OnWin?.Invoke();
    }
}
