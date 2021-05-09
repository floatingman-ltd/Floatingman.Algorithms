namespace Floatingman.Collections
{

    public class Stack<T> : LinkedList<T>
    {
        public bool IsEmpty { get => Head.IsSome(out _); }

        public void Push(T item) { }

        public T Pop()
        {
            return default;
        }
    }
}