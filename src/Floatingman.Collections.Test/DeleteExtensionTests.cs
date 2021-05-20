using Floatingman.Common.Functional;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Floatingman.Collections.Test
{
    // This is using a Bag for simplicity.
    public class DeleteExtensionTests
    {
        [Fact]
        public void Can_Delete_All_Items()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new char[] { };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(0);
            bag.Delete(0);
            bag.Delete(0);
            bag.Delete(0);
            bag.Delete(0);

            using (new AssertionScope())
            {
                bag.Count.Should().Be(0ul);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Delete_An_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new[] { 'a', 'b', 'd', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(2);
            using (new AssertionScope())
            {
                bag.Count.Should().Be(4);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Delete_First_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new[] { 'a', 'b', 'c', 'd' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(0);
            using (new AssertionScope())
            {
                bag.Count.Should().Be(4ul);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Delete_Last_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new[] { 'b', 'c', 'd', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(4);
            using (new AssertionScope())
            {
                bag.Count.Should().Be(4ul);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Delete_Second_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new[] { 'a', 'b', 'c', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(1);
            using (new AssertionScope())
            {
                bag.Count.Should().Be(4ul);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Delete_Third_Item()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var eValues = new[] { 'a', 'b', 'd', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }
            bag.Delete(2);
            using (new AssertionScope())
            {
                bag.Count.Should().Be(4ul);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);
            }
        }

        [Fact]
        public void Can_Enumerate_Over_Values()
        {
            var values = new[] { 'a', 'b', 'c', 'd', 'e' };
            var bag = new Bag<char>();
            foreach (var value in values)
            {
                bag.Add(value);
            }

            var a = bag
                .Where(i => i.IsSome(out var _))
                .Select(i => { i.IsSome(out var x); return x.Item; })
                .ToArray();
            a.Should().BeEquivalentTo(values);
        }

        [Fact]
        public void Can_Get_Enumerator()
        {
            var bag = new Bag<char>();
            var enumerator = bag.GetEnumerator();
            enumerator.Should().BeAssignableTo<IEnumerator<Option<LinkedList<char>.Link>>>();
        }
    }
}