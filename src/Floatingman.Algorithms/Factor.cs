using System.IO;
using System.Linq;


namespace Floatingman.Optimizations
{
    public interface IFactor
    {
        int[] ReadToArray(string file);
        int Count(int[] values);
    }
    public abstract class Factor : IFactor

    {
        public abstract int Count(int[] values);

        public int[] ReadToArray(string file)
        {
            return (File.ReadAllLines(file)).Select(s => int.Parse(s)).ToArray();
        }
    }
}
