// using Xunit;
// using FluentAssertions;

// namespace Floatingman.Optimizations.Tests
// {
//     public class TwoFactorTests
//     {

//         [Theory]
//         [InlineData("1Kints.txt", 1)]
//         [InlineData("2Kints.txt", 2)]
//         [InlineData("4Kints.txt", 3)]
//         public void Test_1k_Ints(string file, int count)
//         {
//             var twoFactor = new TwoFactor();
//             twoFactor.Count(twoFactor.ReadToArray(file)).Should().Be(count);
//         }

//         [Fact]
//         public void Basic()
//         {
//             int[] x = { 1, 2, -2 };
//             var twoFactor = new TwoFactor();
//             twoFactor.Count(x).Should().Be(1);
//         }
//     }
// }
