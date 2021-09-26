using System;
using System.Linq;

namespace Floatingman.Optimizations
{
    public class TwoFactor : Factor, IFactor
    {
        public override int Count(int[] values)
        {
            var sorted = values.OrderBy(i => i).ToList();
            var len = values.Length;
            var count = 0;
            for (int i = 0; i < len; i++)
            {
                if (sorted.BinarySearch(-sorted[i]) > i) count++;
            }
            // for (int i = 0; i < len; i++)
            // {
            //     for (int j = i + 1; j < len; j++)
            //     {
            //         if (values[i] + values[j] == 0) count++;
            //     }
            // }
            return count;
        }
    }
}