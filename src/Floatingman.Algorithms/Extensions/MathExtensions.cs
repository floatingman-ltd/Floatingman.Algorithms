using System;

namespace Floatingman.Algorithms.Extensions
{
    public static class MathExtensions
    {
        public static double Abs(this double value)
        {
            return (value < 0) ? -value : value;
        }

        public static int Abs(this int value)
        {
            return (value < 0) ? -value : value;
        }

        public static double Sqrt(this double value)
        {
            if (value < 0) return double.NaN;
            var eps = 1e-15;
            var temp = value;
            while ((temp - value / temp).Abs() > eps * temp)
            {
                temp = (value / temp + temp) / 2.0;
            }
            return temp;
        }
    }
}