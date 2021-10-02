using Floatingman.Common.Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Floatingman.Algorithms.Collections
{
    public class Bag<T> : LinkedList<T>
    {
        public Bag(IEnumerable<T> enumerable) : base()
        {
            enumerable.ToList().ForEach(v => this.Add(v));
        }

        public Bag() : base()
        {
        }

        public void Add(T item)
        {
            var link = new Link(item);
            link.Next = Head;
            Head = Option<LinkedList<T>.Link>.Some(link);
            Count++;
        }
    }
}