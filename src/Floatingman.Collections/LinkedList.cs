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
        public LinkedList()
        {
            Head = Option<Link>.None;
            Count = 0;
        }

        public ulong Count { get; protected set; }
        protected Option<Link> Head { get; set; }

        private Option<Link> this[ulong index]
        {
            get
            {
                var enumerator = GetEnumerator();
                // loop until the counter reaches the index
                for (var i = 0ul; i <= index; i++)
                {
                    enumerator.MoveNext();
                }
                return enumerator.Current;
            }
        }

        public void Delete(ulong index)
        {
            // this is a fast fail
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

            // last value
            last.IsSome(out var lastValue);
            enumerator.Current.IsSome(out var current);

            while (count < index)
            {
                last.IsSome(out lastValue);
                // next
                enumerator.MoveNext();
                enumerator.Current.IsSome(out current);
                // save the last record
                last = enumerator.Current;
                //increment the counter
                count++;
            }
            // we got here because we looped forward to the record
            lastValue.Next = current.Next;
            Count--;
        }

        public IEnumerator<Option<Link>> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListEnumerator : IEnumerator<Option<Link>>
        {
            // IEnumerator<T> implementation
            private Option<Link> _current;

            private Option<Link> _head;

            private bool _isPreread;

            public LinkedListEnumerator(LinkedList<T> list)
            {
                _head = list.Head;
                _current = list.Head;
                _isPreread = true;
            }

            public Option<Link> Current
            {
                get
                {
                    if (_current.IsSome(out var v))
                    {
                        return _current;
                    }

                    return Option<Link>.None;
                }
            }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose()
            {
            }

            // move first needs to move to the first element in the list first
            public bool MoveNext()
            {
                if (_isPreread)
                {
                    _isPreread = false;
                }
                else
                {
                    _current = _current.Bind((c) => c.Next);
                }
                return _current.IsSome(out var _);
            }

            public void Reset()
            {
                _current = _head;
                _isPreread = true;
            }

            private void IsSome(out object next)
            {
                throw new NotImplementedException();
            }
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