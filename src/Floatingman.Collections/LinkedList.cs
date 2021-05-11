using System;
using System.Collections;
using System.Collections.Generic;

using Floatingman.Common.Functional;

// using static Floatingman.Common.Functional.Option;

namespace Floatingman.Collections
{

    // A basic data structure with no add or delete methods
    public abstract class LinkedList<T> : IEnumerable<T>
    {

        protected Option<Link> Head { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ulong Size { get; protected set; }

        protected LinkedList()
        {
            //Head = Tail;
            //Tail = Option<Link>.None;
            Size = 0;
        }

        private class LinkedListEnumerator : IEnumerator<T>
        {
            public LinkedListEnumerator(LinkedList<T> list)
            {
                list.Head.IsSome(out _current);
            }

            // IEnumerator<T> implementation
            private Link _current;
            public T Current { get { return _current.Item; } }

            // IEnumerator
            public void Reset() { }

            public bool MoveNext()
            {
                return _current.Next.IsSome(out _current);
            }

            object IEnumerator.Current { get { return Current; } }

            // implement IDisposable

            public void Dispose() { }
        }

        protected record Link
        {
            public T Item { get; set; }
            public Option<Link> Next { get; set; }

            public Link(T item)
            {
                Item = item;
                Next = Option<Link>.None;
            }
        }
    }

}
