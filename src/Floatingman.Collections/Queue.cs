using Floatingman.Common.Functional;
 namespace Floatingman.Collections { 
    public class Queue<T> : LinkedList<T>
    {
        private Option<Link> Tail { get; set; }
        public Queue():base()
        {
            Tail = Option<Link>.None;
            Head = Tail;
        }

        public bool IsEmpty { get => !Head.IsSome(out _); }

        public void Enqueue(T item)
        {
            var link = new Link(item);
            link.Next = Head;
            Head = Option<LinkedList<T>.Link>.Some(link);
            Size++;

        }

        public Option<T> Dequeue()
        {
            // set the value to return
            if (Head.IsSome(out var head))
            {
                Size--;
                var value = head.Item;
                Head = head.Next;
                return Option<T>.Some(value);

            }
            return Option<T>.None;

        }
    }
}
