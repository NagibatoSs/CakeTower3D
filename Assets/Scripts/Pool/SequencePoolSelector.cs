using UnityEngine;

public class SequencePoolSelector : IPoolSelector
{
    private int poolIdx = 0;
    public Pool SelectPool(Pool[] pools)
    {
        if (pools == null || pools.Length == 0)
            return null;
        if (poolIdx == pools.Length)
        {
            poolIdx = 0;
        }
        var resultPool = pools[poolIdx];
        poolIdx++;
        return resultPool;
    }
}
