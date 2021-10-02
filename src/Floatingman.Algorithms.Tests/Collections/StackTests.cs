using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using FluentAssertions.Execution;
using Floatingman.Common.Extensions;
using Xunit.Abstractions;

namespace Floatingman.Algorithms.Collections.Test
{
    public class StackTests
    {
        private readonly ITestOutputHelper output;

        public StackTests (ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void NewStack_IsEmpty()
        {
            var stack = new Stack<int>();
            stack.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void NewStack_WithPush_IsNotEmpty()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.IsEmpty.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]

        public void Stack_HasSizeEqualToNumberOfPushes(ulong pushes)
        {
            var stack = new Stack<ulong>();
            for (var i = 0ul; i < pushes; i++)
            {
                stack.Push(i);
            }
            stack.Count.Should().Be(pushes);
        }


        [Fact]

        public void PopOnEmptyReturnNone()
        {
            var stack = new Stack<ulong>();
            stack.Pop().IsSome(out var t).Should().BeFalse();
        }


        [Fact]
        public void Stack_Is_LIFO()
        {
            var records = 10ul;
            var stack = new Stack<ulong>();
            for (var i = 1ul; i <= records; i++)
            {
                stack.Push(i);
            }
            stack.Count.Should().Be(10ul);

            //// secret peek at data structure 
            //var a = stack.ToArray();
            //a.AsJson(output.WriteLine);

            for (var i = records; i > 0ul; i--)
            {
                var v = stack.Pop();
                using (new AssertionScope())
                {
                    v.IsSome(out var t).Should().BeTrue();
                    t.Should().Be(i);
                }
            }
            stack.IsEmpty.Should().BeTrue();
        }
    }
}
