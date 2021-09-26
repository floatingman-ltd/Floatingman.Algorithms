namespace Floatingman.Algorithms
{
    public interface IUnionFind
    {
        void Add(int p, int q);
        bool AreConnected(int p, int q);
        int Count();
        int Find(int p);
        void Union(int p, int q);


    }
}
