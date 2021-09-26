using Floatingman.Common.Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Floatingman.Collections
{
    public class Stack<T> : LinkedList<T>
    {
        public Stack(IEnumerable<T> enumerable) : this()
        {
            enumerable.ToList().ForEach(v => this.Push(v));
        }

        public Stack() : base()
        {
            Head = Option<Link>.None;
        }

        public bool IsEmpty { get => !Head.IsSome(out _); }

        public Option<T> Pop()
        {
            // set the value to return
            if (Head.IsSome(out var head))
            {
                Count--;
                var value = head.Item;
                Head = head.Next;
                return Option<T>.Some(value);
            }
            return Option<T>.None;
        }

        public void Push(T item)
        {
            var link = new Link(item);
            link.Next = Head;
            Head = Option<LinkedList<T>.Link>.Some(link);
            Count++;
        }
    }
}