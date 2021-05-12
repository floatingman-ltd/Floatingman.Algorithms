﻿using Floatingman.Common.Functional;
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
    public class BagTests
    {
        [Fact]
        public void BagCanAdd()
        {
            var bag = new Bag<char>();
            bag.Add('k');
            bag.Count.Should().Be(1);
        }

        // strictly speaking this is the same test for all classes that implement LinkedList<T>
        [Fact]
        public void CanGetEnumerater()
        {
            var bag = new Bag<char>();
            var enumerator = bag.GetEnumerator();
            enumerator.Should().BeAssignableTo<IEnumerator<Option<LinkedList<char>.Link>>>();
        }

        [Fact]
        public void CanEnumerateOverValues()
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
        public void CanDeleteAnItem()
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
                bag.Count.Should().Be(4);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);

            }
        }


        [Fact]
        public void CanDeleteFirstItem()
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
                bag.Count.Should().Be(4);
                var a = bag
                    .Where(i => i.IsSome(out var _))
                    .Select(i => { i.IsSome(out var x); return x.Item; })
                    .ToArray();
                a.Should().BeEquivalentTo(eValues);

            }
        }

    }
}