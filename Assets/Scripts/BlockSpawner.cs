using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BlockSpawner : MonoBehaviour
{
    [Inject] TowerManager towerManager;
    [SerializeField] Pool[] pools;
    private IPoolSelector poolSelector;

    [Inject]
    public void Construct(IPoolSelector poolSelector)
    {
        this.poolSelector = poolSelector;
    }

    private void OnEnable()
    {
        towerManager.OnBlockAdded += SpawnNewBlock;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= SpawnNewBlock;
    }
    public void StartGame()
    {
        Spawn();
    }

    private void SpawnNewBlock(GameObject newBlock)
    {
        Spawn();
    }

    private void Spawn()
    {
        var pool = poolSelector.SelectPool(pools);
        var block = pool.GetFromPool();
        block.transform.SetParent(pool.transform);
        block.transform.position = transform.position;
        block.transform.rotation = Quaternion.identity;
        towerManager.Subscribe(block.gameObject);
    }
}
