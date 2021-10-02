using Floatingman.Common.Functional;
using Floatingman.Algorithms.Collections;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Floatingman.Collections.Test
{
    public class FindExtensionTests
    {
        [Fact]
        public void Return_None_If_Not_Found()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var bag = new Bag<char>(values);
            bag.Find('f').Should().Be(Option<ulong>.None);
        }

        [Fact]
        public void Return_Some_Index_If_Found()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var bag = new Bag<char>(values);

            var i = 0ul;
            foreach (var value in values.Reverse())
            {
                bag.Find(value).Should().Be(Option<ulong>.Some(i));
                i++;
            }
        }
    }
}