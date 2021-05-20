using System;
using System.Collections;
using Floatingman.Common.Functional;

namespace Floatingman.Collections
{
    public static class LinkedListExtensions
    {
        public static void Delete<T>(this LinkedList<T> list, ulong index)
        {
            // this is a fast fail
            if (index >= list.Count) return;
            var enumerator = list.GetEnumerator();
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

        public static Option<ulong> Find<T>(this LinkedList<T> list, T value)
                where T : IEquatable<T>
        {
            var index = 0ul;
            foreach (var v in list)
            {
                v.IsSome(out var l);
                if (l.Item.Equals(value))
                {
                    return Option<ulong>.Some(index);
                }
                index++;
            }

            return Option<ulong>.None;
        }

        public static IEnumerable Reverse<T>(this LinkedList<T> list)
        {
            var outlist = new LinkedList<T>();
            var next = outlist.Head;
            foreach (var item in list)
            {
                item.
                var link = item;
                link.Bind()
                next = item;
                yield return outlist;
            }
        }
    }
}