using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [Inject] private GameStateMachine stateMachine;
    [SerializeField] private GameObject safeAreaUi;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    private GameObject currentCanvas;

    private void OnEnable()
    {
        stateMachine.OnStateChanged += OpenGameStateUI;
    }
    private void OnDisable()
    {
        stateMachine.OnStateChanged -= OpenGameStateUI;
    }

    private void Start()
    {
        currentCanvas = menuCanvas;
    }

    private void OpenGameStateUI(GameState state)
    {
        if (currentCanvas != null)
            currentCanvas.SetActive(false);
        switch (state)
        {
            case GameState.Menu:
                SetCanvasActive(menuCanvas);
                break;

            case GameState.Game:
                SetCanvasActive(gameCanvas);
                break;

            case GameState.Lose:
                SetCanvasActive(loseCanvas);
                break;

            case GameState.Win:
                SetCanvasActive(winCanvas);
                break;
        }
    }
    private void SetCanvasActive(GameObject canvas)
    {
        canvas.SetActive(true);
        currentCanvas = canvas;
    }

}
