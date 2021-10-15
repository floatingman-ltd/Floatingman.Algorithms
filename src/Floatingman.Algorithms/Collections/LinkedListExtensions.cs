using System;
using System.Collections;
using Floatingman.Common.Functional;

namespace Floatingman.Algorithms.Collections
{
    public static class LinkedListExtensions
    {
        public static void Delete<T>(this LinkedList<T> list, T item, bool all = false)
        where T : IEquatable<T>
        {
            var opt = list.Head;
            opt.IsSome(out var lastItem);
            if (opt.IsSome(out var listItem))
            {
                // there is no short way through the list 
                while (listItem.Next.IsSome(out listItem))
                {
                    if (item.Equals(listItem.Item))
                    {
                        lastItem.Next = listItem.Next;
                        listItem = null;
                        list.Count--;
                        if (!all)
                        {
                            return;
                        }
                    }
                    lastItem = listItem;
                }
            }
        }

        public static void Delete<T>(this LinkedList<T> list, ulong index)
        {
            // this is a fast fail
            if (index >= list.Count) return;
            var enumerator = list.GetLinkEnumerator();
            var count = 0ul;
            var last = list.Head;

            // special case of removing head
            if (index == 0ul)
            {
                list.Head.IsSome(out var next);
                list.Head = next.Next;
            }

            // last value
            last.IsSome(out var lastValue);
            enumerator.Current.IsSome(out var current);

            while (count <= index)
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
            list.Count--;
        }

        public static LinkedList<T> Filter<T>(this LinkedList<T> list, Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public static Option<ulong> Find<T>(this LinkedList<T> list, T value)
                where T : IEquatable<T>
        {
            var index = 0ul;
            var enumerator = list.GetLinkEnumerator();
            while (enumerator.MoveNext())
            {
                var v = enumerator.Current;

                v.IsSome(out var l);
                if (l.Item.Equals(value))
                {
                    return Option<ulong>.Some(index);
                }
                index++;
            }

            return Option<ulong>.None;
        }

        public static LinkedList<U> Map<T, U>(this LinkedList<T> list, Func<T, U> f)
        {
            throw new NotImplementedException();
        }

        public static LinkedList<T> Reverse<T, TCollection>(this LinkedList<T> list)
        where TCollection : LinkedList<T>, new()
        {
            var outlist = new TCollection();
            var head = Option<LinkedList<T>.Link>.None;
            var current = head;
            var enumerator = list.GetLinkEnumerator();
            while (enumerator.MoveNext())
            {
                var v = enumerator.Current;
                v.IsSome(out var link);
                var item = new LinkedList<T>.Link(link.Item);
                var next = Option<LinkedList<T>.Link>.Some(item);

                item.Next = current;
                current = next;
            }
            outlist.Head = current;
            return outlist;
        }

        public static LinkedList<T> Sort<T>(this LinkedList<T> list) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }
    }
}