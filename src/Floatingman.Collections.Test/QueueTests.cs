using Floatingman.Common.Extensions;
using Floatingman.Common.Functional;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Floatingman.Collections.Test
{
    public class QueueTests
    {

        private readonly ITestOutputHelper output;

        public QueueTests (ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void NewQueueIsEmpty()
        {
            var queue = new Queue<int>();
            queue.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void QueueSizeEqualsNumberOfQueues()
        {
            var queue = new Queue<int>();
            queue.Enqueue(342);
            queue.Count.Should().Be(1);
        }


        [Fact]
        public void EmptyQueueDequeuesNone()
        {
            var queue = new Queue<char>();
            queue.Dequeue().IsSome(out var _).Should().BeFalse();
        }

        [Fact]
        public void QueueIsFIFO()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var queue = new Queue<char>();
            foreach (var value in values)
            {
                queue.Enqueue(value);
            }
            queue.Count.Should().Be(5ul);

            //// secret peek at data structure 
            //var a = queue.ToArray();
            //a.AsYaml(output.WriteLine);

            foreach (var value in values)
            {
                var v = queue.Dequeue();
                using (new AssertionScope())
                {
                    v.IsSome(out var t).Should().BeTrue();
                    t.Should().Be(value);
                }
            }
            queue.IsEmpty.Should().BeTrue();
        }
    }
}
