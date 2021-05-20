using System;
using System.Collections;
using System.Collections.Generic;

using Floatingman.Common.Functional;

// using static Floatingman.Common.Functional.Option;

namespace Floatingman.Collections
{
    // A basic data structure with no add or delete methods
    public class LinkedList<T> : IEnumerable<T>
    {
        protected internal LinkedList()
        {
            Head = Option<Link>.None;
            Count = 0;
        }

        public ulong Count { get; internal set; }

        protected internal Option<Link> Head { get; set; }

        private T this[ulong index]
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

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal IEnumerator<Option<Link>> GetLinkEnumerator() => new LinkEnumerator(this);

        private class LinkedListEnumerator : IEnumerator<T>
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

            public T Current
            {
                get
                {
                    if (_current.IsSome(out var v))
                    {
                        return v.Item;
                    }

                    return default;
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
        }

        private class LinkEnumerator : IEnumerator<Option<Link>>
        {
            // IEnumerator<T> implementation
            private Option<Link> _current;

            private Option<Link> _head;

            private bool _isPreread;

            public LinkEnumerator(LinkedList<T> list)
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