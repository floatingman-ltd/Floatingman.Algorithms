using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using FluentAssertions.Execution;

namespace Floatingman.Collections.Test
{
    public class StackTests
    {
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
            stack.Size.Should().Be(pushes);
        }


        [Fact]

        public void PopOnEmptyReturnNone()
        {
            var stack = new Stack<ulong>();
            stack.Pop().IsSome(out var t).Should().BeFalse();
        }


        [Fact]
        public void PopsReturnsInReverseOrder()
        {
            var records = 10ul;
            var stack = new Stack<ulong>();
            for (var i = 1ul; i <= records; i++)
            {
                stack.Push(i);
            }
            stack.Size.Should().Be(10ul);

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
