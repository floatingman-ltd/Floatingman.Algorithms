using FluentAssertions;
using Xunit;

namespace Floatingman.Algorithms.Extensions.Tests
{
    public class ArrayExtensionsTests
    {

        [Fact]
        public void Can_Find_Last_Max_Value()
        {
            var a = new[] { 1, 2, 3, 4, 5 };
            a.Max().Should().Be(5);
        }

        [Fact]
        public void Can_Find_First_Value()
        {
            var a = new[] { 5, 4, 3, 2, 1 };
            a.Max().Should().Be(5);
        }

        [Fact]
        public void Returns_Zero_For_Empty_Array()
        {
            var a = new double[0];
            a.Max().Should().Be(0);
        }
    }
}