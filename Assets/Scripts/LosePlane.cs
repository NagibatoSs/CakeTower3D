using UnityEngine;
using Zenject;

public class LosePlane : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    [Inject] GameStateMachine gameStateMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (towerManager.TowerRoot == other.gameObject)
            return;
        gameStateMachine.SetLose();
    }
}
