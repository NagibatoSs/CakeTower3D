using UnityEngine;

public interface IPoolSelector
{
    Pool SelectPool(Pool[] pools);
}
