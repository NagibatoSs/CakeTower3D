using UnityEngine;
using Zenject;

public class BlockAnimationHandler : MonoBehaviour
{
    [Inject] TowerManager towerManager;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += SetAnimationEvent;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= SetAnimationEvent;
    }

    private void SetAnimationEvent(GameObject newBlock)
    {
        newBlock.GetComponent<BlockAnimateColor>()?.Animate();
    }
}
