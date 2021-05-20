using Floatingman.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Floatingman.Collections.Usage
{
    internal class Program
    {
        private static void BagTheRecords(char[] values)
        {
            Console.WriteLine("Bag");
            var bag = new Bag<char>();
            char[] array = null;
            foreach (var value in values)
            {
                bag.Add(value);
                array = ShowAndTell(bag);
            }
            bag.Delete(2);
            array = ShowAndTell(bag);
        }

        private static void Main(string[] args)
        {
            var values = new[] { '0', '1', '2', '3', '4' };
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            QueueTheRecords(values);
            StackTheRecords(values);
            BagTheRecords(values);

            VisualDelete(values);

            Reverse(values);
        }

        private static void QueueTheRecords(char[] values)
        {
            Console.WriteLine("Queue");
            var queue = new Queue<char>();
            char[] array = null;
            foreach (var value in values)
            {
                queue.Enqueue(value);
                array = ShowAndTell(queue);
            }
            queue.Delete(0);
            array = ShowAndTell(queue);
        }

        private static void Reverse(char[] values)
        {
            Console.WriteLine("Reverse");
            var queue = new Queue<char>(values);
            new { queue = queue.ToArray() }.AsJson();
            new { reverse = queue.Reverse().ToArray() }.AsJson();

            var stack = new Stack<char>(values);
            new { stack = stack.ToArray() }.AsJson();
            new { reverse = stack.Reverse().ToArray() }.AsJson();

            var bag = new Bag<char>(values);
            new { bag = bag.ToArray() }.AsJson();
            new { reverse = bag.Reverse().ToArray() }.AsJson();
        }

        private static char[] ShowAndTell(LinkedList<char> collection)
        {
            char[] array = collection
                .Where(v => v.IsSome(out var _))
                .Select(v => { v.IsSome(out var x); return x.Item; })
                .ToArray();
            array.AsJson();
            return array;
        }

        private static void StackTheRecords(char[] values)
        {
            Console.WriteLine("Stack");
            var stack = new Stack<char>();
            char[] array = null;
            foreach (var value in values)
            {
                stack.Push(value);
                array = ShowAndTell(stack);
            }
            stack.Delete(1);
            array = ShowAndTell(stack);
        }

        private static void VisualDelete(char[] values)
        {
            Console.WriteLine("Visual Delete");
            for (var i = 0ul; i < (ulong)values.Length; i++)
            {
                var list = new Queue<char>(values);
                Console.Write("    "); ShowAndTell(list);
                list.Delete(i);
                Console.Write($"{i} - "); ShowAndTell(list);
            }
        }
    }
}