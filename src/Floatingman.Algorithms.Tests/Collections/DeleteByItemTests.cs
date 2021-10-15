using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Floatingman.Algorithms.Collections.Test
{
    // This is using a Bag for simplicity.
    public class DeleteByItemExtensionTests
    {
        [Fact]
        public void Can_Delete_First_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new char[] { 'b', 'c', 'd', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete('a');

            using (new AssertionScope())
            {
                bag.Count.Should().Be(4ul);
                var a = bag.ToArray();
                a.Should().BeEquivalentTo(eValues);
            }

        }
    }
}