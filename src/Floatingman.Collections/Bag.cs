using Floatingman.Common.Functional;
using System;

namespace Floatingman.Collections
{
    public class Bag<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            var link = new Link(item);
            link.Next = Head;
            Head = Option<LinkedList<T>.Link>.Some(link);
            Count++;
        }
    }
}