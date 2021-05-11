using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Floatingman.Collections.Test
{
    public class QueueTests
    {
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
            queue.Size.Should().Be(1);
        }
    }
}
