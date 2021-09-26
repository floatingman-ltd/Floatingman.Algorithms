using System;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Floatingman.Optimizations.Tests
{

    public class ThreeFactorTests
    {

        [Theory]
        [InlineData("1Kints.txt", 70)]
        [InlineData("2Kints.txt", 528)]
        [InlineData("4Kints.txt", 4039)]
        public void Test_1k_Ints(string file, int count)
        {
            var threeFactor = new ThreeFactor();
            threeFactor.Count(threeFactor.ReadToArray(file)).Should().Be(count);
        }

        [Fact]
        public void Basic()
        {
            int[] x = { 1, 2, -3 };
            var threeFactor = new ThreeFactor();
            threeFactor.Count(x).Should().Be(1);
        }
    }
}
