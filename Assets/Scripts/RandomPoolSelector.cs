using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomPoolSelector : IPoolSelector
{
    public Pool SelectPool(Pool[] pools)
    {
        if (pools == null || pools.Length == 0)
            return null;
        var rnd = new Random();
        var rndIdx = rnd.Next(0, pools.Length);
        return pools[rndIdx];
    }
}
