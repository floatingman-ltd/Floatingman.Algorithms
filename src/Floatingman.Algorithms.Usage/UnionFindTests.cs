// using System;
// using System.IO;
// using System.Linq;
// using System.Threading.Tasks;
// using FluentAssertions;
// using Xunit;
// using Xunit.Abstractions;

// using Floatingman.Algorithms;

// namespace Floatingman.Algorithims.Test
// {
//     public class UnionFindTests
//     {
//         private readonly ITestOutputHelper output;

//         public UnionFindTests(ITestOutputHelper output)
//         {
//             this.output = output;
//         }
//         [Theory]
//         [InlineData("tinyUF.txt", 2)]
//         [InlineData("mediumUF.txt", 3)]
//         // [InlineData("largeUF.txt", 6)]
//         public async Task Number_of_components(string source, int expected)
//         {
//             this.output.WriteLine($"Processing {source}");
//             Console.WriteLine($"Processing {source}");
//             using var reader = new StreamReader(source);
//             var size = int.Parse(await reader.ReadLineAsync());
//             var uf = new UnionFind(size);
//             uf.SetQuickFindAlgorithm();
//             uf.SetQuickUnionAlgorithm();
//             uf.SetWeightedQuickUnionAlgorithm();
//             var hasLine = true;
//             var line = 0;
//             while (hasLine)
//             {
//                 var components = await reader.ReadLineAsync();
//                 hasLine = components != null;
//                 if (hasLine)
//                 {
//                     var values = components.Split(" ").Select(v => int.Parse(v)).ToArray();
//                     Console.Write($"{line++}:");
//                     uf.Add(values[0], values[1]);
//                     Console.WriteLine();
//                 }
//             }
//             uf.Count().Should().Be(expected);
//         }
//     }
// }
