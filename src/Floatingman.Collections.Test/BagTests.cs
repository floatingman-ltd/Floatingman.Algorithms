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
        public void Can_Add()
        {
            var bag = new Bag<char>();
            bag.Add('k');
            bag.Count.Should().Be(1);
        }

    }
}
