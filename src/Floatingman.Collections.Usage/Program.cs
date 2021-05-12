using Floatingman.Common.Extensions;
using System;
using System.Linq;

namespace Floatingman.Collections.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            QueueTheRecords(values);
            StackTheRecords(values);
            BagTheRecords(values);
        }

        private static void BagTheRecords(char[] values)
        {
            Console.WriteLine("Bag");
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
                var a = bag
                    .Where(v => v.IsSome(out var _))
                    .Select(v => { v.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.AsJson();
            }

        }

        private static void StackTheRecords(char[] values)
        {
            Console.WriteLine("Stack");
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            var stack = new Stack<char>();
            foreach (var value in values)
            {
                stack.Push(value);
                var a = stack
                    .Where(v => v.IsSome(out var _))
                    .Select(v => { v.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.AsJson();
            }

        }
        private static void QueueTheRecords(char[] values)
        {
            Console.WriteLine("Queue");
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            var queue = new Queue<char>();
            foreach (var value in values)
            {
                queue.Enqueue(value);
                var a = queue
                    .Where(v => v.IsSome(out var _))
                    .Select(v => { v.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.AsJson();
            }

        }
    }
}
