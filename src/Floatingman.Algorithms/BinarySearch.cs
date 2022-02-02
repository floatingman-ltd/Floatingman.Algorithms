namespace Floatingman.Algorithms
{
    public static class BinarySearch
    {
        public static int IndexOf(int[] a, int key)
        {
            var low = 0;
            var high = a.Length - 1;
            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (key < a[mid]) high = mid - 1;
                else if (key > a[mid]) low = mid + 1;
                else return mid;
            }
            return -1;
        }

    }
}