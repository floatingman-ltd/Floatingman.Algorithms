using Floatingman.Common.Functional;

namespace Floatingman.Collections
{
    public class Queue<T> : LinkedList<T>
    {
        private Option<Link> Tail { get; set; }
        public Queue() : base()
        {
            Tail = Option<Link>.None;
        }

        public bool IsEmpty { get => !Head.IsSome(out _); }

        // add to the tail
        public void Enqueue(T item)
        {
            var link = Option<LinkedList<T>.Link>.Some(new Link(item));

            // we have multiple records
            if (Tail.IsSome(out var tail))
            {
                tail.Next = link;
            }
            else
            {
                //if (Head.IsSome(out var head))
                //{
                //    head.Next = link;
                //}
                //else
                //{
                    Head = link;
                //}
            }
            Tail = link;
            Count++;
        }

        // remove from the head
        public Option<T> Dequeue()
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
    }
}
