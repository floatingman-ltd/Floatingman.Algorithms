using System.Collections;
using System.Collections.Generic;

using Floatingman.Common.Functional;

// using static Floatingman.Common.Functional.Option;

namespace Floatingman.Collections
{

    // A basic data structure with no add or delete methods
    public abstract class LinkedList<T> : IEnumerable<Option<T>>
    {

        protected Option<Link> Head { get; set; }

        public IEnumerator<Option<T>> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ulong Count { get; protected set; }

        protected LinkedList()
        {
            Head = Option<Link>.None;
            Count = 0;
        }

        private class LinkedListEnumerator : IEnumerator<Option<T>>
        {

            private ulong _index = 0ul;
            public LinkedListEnumerator(LinkedList<T> list)
            {
                _current = list.Head;
            }

            // IEnumerator<T> implementation
            private Option<Link> _current;

            public Option<T> Current
            {
                get
                {
                    if (_current.IsSome(out var v))
                    {
                        return Option<T>.Some(v.Item);
                    }

                    return Option<T>.None;
                }
            }


            // IEnumerator
            public void Reset() { }

            // move first needs to move to the first element in the list first
            public bool MoveNext()
            {
                // poosibley sitting on the first element already
                if (_index == 0ul)
                {
                    _index++;
                    return _current.IsSome(out var _);
                }
                else
                {

                    return getAndSetNext();

                }

                bool getAndSetNext()
                {
                    if (_current.IsSome(out var v))
                    {
                        _current = v.Next;
                        return true;
                    }
                    return false;

                }
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
