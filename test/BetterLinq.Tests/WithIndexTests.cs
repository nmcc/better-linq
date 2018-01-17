using System;
using System.Collections.Generic;
using System.Linq;
using BetterLinq;
using FluentAssertions;
using Xunit;

namespace BetterLinq.Tests
{
    public class WithIndexTests
    {
        [Fact]
        public void WithIndex_Null()
        {
            // Arrange
            const IEnumerable<string> collection = null;

            // Act + Assert
            collection.WithIndex().Should().NotBeNull();
            collection.WithIndex().Count().Should().Be(0);
        }

        [Fact]
        public void WithIndex_ZeroItems()
        {
            // Arrange
            var collection = new List<string>();

            // Act + Assert
            collection.WithIndex().Should().NotBeNull();
            collection.WithIndex().Count().Should().Be(0);
        }

        [Fact]
        public void WithIndex_TwoItems()
        {
            // Arrange
            var collection = new List<string> { "a", "b" };

            // Act + Assert
            collection.WithIndex().Should().NotBeNull();
            collection.WithIndex().Count().Should().Be(2);
            collection.WithIndex().ElementAt(0).Index.Should().Be(0);
            collection.WithIndex().ElementAt(0).Value.Should().Be("a");

            collection.WithIndex().ElementAt(1).Index.Should().Be(1);
            collection.WithIndex().ElementAt(1).Value.Should().Be("b");
        }
    }
}
