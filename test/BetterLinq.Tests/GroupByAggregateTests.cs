using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BetterLinq.Tests
{
    public class GroupByAggregateTests
    {
        [Fact]
        public void When_NullCollection_ReturnNull()
        {
            IEnumerable<int> collection = null;

            collection.GroupByAggregate(x => x, x => x).Should().BeNull();
        }

        [Fact]
        public void When_EmptyKeySelectorParameter_ThrowArgumentNullException()
        {
            IEnumerable<int> collection = new List<int>();

            Action act = () => collection.GroupByAggregate<int, int, int>(null, x => x);

            act.ShouldThrow<ArgumentNullException>()
                .WithMessage("Value cannot be null.\r\nParameter name: keySelector");
        }

        [Fact]
        public void When_EmptyElementSelectorParameter_ThrowArgumentNullException()
        {
            IEnumerable<int> collection = new List<int>();

            Action act = () => collection.GroupByAggregate<int, int, int>(x => x, null);

            act.ShouldThrow<ArgumentNullException>()
                .WithMessage("Value cannot be null.\r\nParameter name: elementSelector");
        }
    }
}
