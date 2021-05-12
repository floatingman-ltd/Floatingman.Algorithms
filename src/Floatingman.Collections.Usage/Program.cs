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
        }

        private static void StackTheRecords(char[] values)
        {
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            var stack = new Stack<char>();
            foreach (var value in values)
            {
                stack.Push(value);
                var a = stack
                    .Where(v => v.IsSome(out var _))
                    .Select(v => { v.IsSome(out var x); return x; })
                    .ToArray();
                a.AsJson();
            }

        }
        private static void QueueTheRecords(char[] values)
        {
            DumpExtensions.JsonFormatting = Newtonsoft.Json.Formatting.None;
            var queue = new Queue<char>();
            foreach (var value in values)
            {
                queue.Enqueue(value);
                var a = queue
                    .Where(v => v.IsSome(out var _))
                    .Select(v => { v.IsSome(out var x); return x; })
                    .ToArray();
                a.AsJson();
            }

        }
    }
}
