using System;

namespace Floatingman.Algorithms.Extensions
{
    public static class ArrayExtensions
    {

        public static T Max<T>(this T[] array) where T : IComparable
        {
            var length = array.Length;
            if (length <= 0) return default(T);
            var max = array[0];
            for (var i = 0; i < length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static double Average(this double[] array)
        {
            var length = array.Length;
            var sum = default(double);
            if (length <= 0) return sum;
            for (var i = 0; i < length; i++)
            {
                sum += array[i];
            }
            return sum / length;
        }

        public static T[] Copy<T>(this T[] array)
        {
            var length = array.Length;
            var copy = new T[length];
            for (var i = 0; i < length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

        public static T[] Reverse<T>(this T[] array)
        {
            var length = array.Length;
            var reverse = new T[length];
            for (var i = 0; i < length; i++)
            {
                reverse[length - (i + 1)] = array[i];
            }
            return reverse;
        }

    }
}