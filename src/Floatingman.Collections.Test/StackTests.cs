using System;
using Xunit;
using FluentAssertions;

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
    }
}
