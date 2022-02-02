using System.IO;
using System.Linq;

namespace Floatingman.Algorithms
{
    public static class FileReader
    {

        public static int[] ReadInts(string fileName)
        {
            return File.ReadLines(fileName).Select(s => int.Parse(s)).ToArray();
        }
    }
}