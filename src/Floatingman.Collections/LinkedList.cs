using System;
using System.Collections;
using System.Collections.Generic;

using Floatingman.Common.Functional;

// using static Floatingman.Common.Functional.Option;

namespace Floatingman.Collections
{

    // A basic data structure with no add or delete methods
    public abstract class LinkedList<T> : IEnumerable<Option<LinkedList<T>.Link>>
    {

        protected Option<Link> Head { get; set; }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Delete(ulong index)
        {
            if (index >= Count) return;
            var enumerator = GetEnumerator();
            var count = 0ul;
            var last = Head;

            // special case of removing head
            if (index == 0ul)
            {
                Head.IsSome(out var next);
                Head = next.Next;
            }

            while (count <= index)
            {
                // last value
                last.IsSome(out var lastV);
                // next
                enumerator.MoveNext();
                enumerator.Current.IsSome(out var current);
                lastV.Next = current.Next;
                // save the last record
                last = enumerator.Current;
                //increment the counter
                count++;
            }
            Count--;
        }

        public IEnumerator<Option<Link>> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        public ulong Count { get; protected set; }

        protected LinkedList()
        {
            Head = Option<Link>.None;
            Count = 0;
        }

        private class LinkedListEnumerator : IEnumerator<Option<Link>>
        {

            private ulong _index = 0ul;
            public LinkedListEnumerator(LinkedList<T> list)
            {
                _current = list.Head;
            }

            // IEnumerator<T> implementation
            private Option<Link> _current;

            public Option<Link> Current
            {
                get
                {
                    if (_current.IsSome(out var v))
                    {
                        return _current;
                        //return Option<T>.Some(v.Item);
                    }

                    return Option<Link>.None;
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

        public record Link
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
