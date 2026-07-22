using System;
using System.Collections;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] Transform blocksRoot;
    [SerializeField] float crunchDuration = 0.015f;
    public GameObject TowerRoot { get; private set; }

    private Tower tower = new Tower();
    public GameObject TowerPeek => tower.Peek;
    public int BlocksCount => tower.Count;

    private LandingDetector currentDetector;

    public event Action<GameObject> OnCrunch;
    public event Action<GameObject> OnBlockAdded;
    public void Subscribe(GameObject block)
    {
        if (currentDetector != null)
            currentDetector.OnLanded -= HandleBlockLanded;

        currentDetector = block.GetComponent<LandingDetector>();
        if (currentDetector != null)
            currentDetector.OnLanded += HandleBlockLanded;
    }

    private void OnDisable()
    {
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
            currentDetector = null;
        }
    }
    public void ResetTower()
    {
        tower.ClearAndDestroy();

        foreach (var poolItem in blocksRoot.GetComponentsInChildren<PoolItem>(true))
        {
            if (poolItem.gameObject.activeSelf)
                poolItem.ReturnToPool();
        }

        TowerRoot = null;
    }
    private void HandleBlockLanded(GameObject block)
    {
        StartCoroutine(PushWithCrunchSequence(block));
    }

    private IEnumerator PushWithCrunchSequence(GameObject newBlock)
    {
        while (tower.Count > 0)
        {
            GameObject peek = tower.Peek;
            if (newBlock.transform.localScale.x > peek.transform.localScale.x)
            {
                yield return CrunchPeekBlock(peek);
            }
            else break;
        }
        if (tower.Count == 0)
        {
            TowerRoot = newBlock;
        }
        
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
            currentDetector = null;
        }
        tower.Push(newBlock);
        OnBlockAdded?.Invoke(newBlock);
    }

    private IEnumerator CrunchPeekBlock(GameObject peek)
    {
        OnCrunch?.Invoke(peek);
        tower.Pop();

        yield return new WaitForSeconds(crunchDuration);
        peek.GetComponent<PoolItem>().ReturnToPool();
    }
}
