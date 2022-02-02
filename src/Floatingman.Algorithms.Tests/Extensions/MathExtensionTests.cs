using FluentAssertions;
using Xunit;

namespace Floatingman.Algorithms.Extensions.Tests
{
    public class MathExtensionTests
    {

        [Fact]
        public void Can_Get_Square_Root()
        {
            var x = 9.0;
            x.Sqrt().Should().Be(3.0);
        }

        [Fact]
        public void Square_Root_Returns_NaN_for_Negative_Values()
        {
            var x = -9.0;
            x.Sqrt().Should().Be(double.NaN);
        }

        [Fact]
        public void Can_Get_Absolute_Value_of_Double()
        {
            var x = -10.0;
            x.Abs().Should().Be(10.0);
        }

        [Fact]
        public void Can_Get_Absolute_Value_of_Int()
        {
            var x = -10;
            x.Abs().Should().Be(10);
        }
    }
}