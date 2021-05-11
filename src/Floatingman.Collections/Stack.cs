using Floatingman.Common.Functional;
 namespace Floatingman.Collections { 
    public class Stack<T> : LinkedList<T>
    {
        public Stack():base()
        {
            Head = Option<Link>.None;
        }

        public bool IsEmpty { get => !Head.IsSome(out _); }

        public void Push(T item)
        {
            var link = new Link(item);
            link.Next = Head;
            Head = Option<LinkedList<T>.Link>.Some(link);
            Size++;

        }

        public Option<T> Pop()
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