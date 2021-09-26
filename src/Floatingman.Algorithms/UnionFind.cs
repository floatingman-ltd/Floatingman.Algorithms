using System;
using System.Linq;

namespace Floatingman.Algorithms
{
    public class UnionFind : IUnionFind
    {

        private int[] _components;
        private int _count;
        public UnionFind(int size)
        {
            _components = Enumerable.Range(0, size).ToArray();
            _count = size;

            // default implementation is QuickFind
            _findFunc = QuickFind;
            _unionFunc = QuickFindUnion;
        }

        public void Add(int p, int q)
        {
            if (!AreConnected(p, q))
            {
                Union(p, q);
                Console.Write($"[{p}, {q}]");
            }
        }

        private Action<int, int> _unionFunc;
        private Func<int, int> _findFunc;
        public int Find(int p)
        {
            return _findFunc(p);
        }

        public bool AreConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Count()
        {
            return _count;
        }

        public void Union(int p, int q)
        {
            _unionFunc(p, q);
        }

        // Quick Find
        public void SetQuickFindAlgorithm()
        {
            _findFunc = QuickFind;
            _unionFunc = QuickFindUnion;
        }

        public int QuickFind(int p)
        {
            // quick find implementation
            return _components[p];
        }

        private void QuickFindUnion(int p, int q)
        {
            // quick find implementation
            int pId = Find(p);
            int qId = Find(q);
            if (pId != qId)
            {
                for (var i = 0; i < _components.Length; i++)
                {
                    if (_components[i] == pId)
                    {
                        _components[i] = qId;
                    }
                }
                _count--;
            }
        }

        // Quick Union
        public void SetQuickUnionAlgorithm()
        {
            _findFunc = QuickUnionFind;
            _unionFunc = QuickUnion;
        }

        public int QuickUnionFind(int p)
        {
            // quick union implementation
            // this mutates the parameter
            while (p != _components[p])
            {
                p = _components[p];
            }
            return p;
        }

        private void QuickUnion(int p, int q)
        {
            // quick union implementation
            int pId = Find(p);
            int qId = Find(q);
            if (pId != qId)
            {
                _components[pId] = qId;
                _count--;
            }
        }

        #region Weighted Quick Union

        private int[] _size;
        public void SetWeightedQuickUnionAlgorithm()
        {
            _findFunc = QuickUnionFind;
            _unionFunc = WeightedQuickUnion;
            _size = Enumerable.Range(0, _components.Length).ToArray();
        }

        private void WeightedQuickUnion(int p, int q)
        {
            // quick union implementation
            int i = Find(p);
            int j = Find(q);
            if (i != j)
            {
                if (_size[i] < _size[j])
                {
                    _components[i] = j;
                    _size[j] += _size[i];
                }
                else
                {
                    _components[j] = i;
                    _size[i] += _size[j];
                }
                _count--;
            }
        }
        #endregion
    }
}
