using UnityEngine;
using Zenject;

public class UIPanel : MonoBehaviour
{
    [Inject] GameStateMachine gameStateMachine;

    public void OnRetryClicked()
    {
        gameStateMachine.SetGame();
    }
    public void OnQuitClicked()
    {
        gameStateMachine.SetMenu();
    }

    public void OnContinueClicked()
    {
        gameStateMachine.SetGame();
    }
}
