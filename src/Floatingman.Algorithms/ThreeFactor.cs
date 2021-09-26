using System;
using System.Collections.Generic;
using System.Linq;

namespace Floatingman.Optimizations
{

    public class ThreeFactor : Factor
    {
        public override int Count(int[] values)
        {
            var len = values.Length;
            var count = 0;
            var sorted = values.OrderBy(i => i).ToList();
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (sorted.BinarySearch(-(sorted[i] + sorted[j])) > j) count++;
                }
            }
            // for (int i = 0; i < len; i++)
            // {
            //     for (int j = i + 1; j < len; j++)
            //     {
            //         for (int k = j + 1; k < len; k++)
            //         {
            //             if (values[i] + values[j] + values[k] == 0) count++;
            //         }
            //     }
            // }
            return count;
        }

    }
}
