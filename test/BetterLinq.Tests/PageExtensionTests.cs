using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace BetterLinq.Tests
{
    public class PageExtensionTests
    {
        [Fact]
        public void Page_Null()
        {
            // Arrange
            IEnumerable<int> collection = null;

            // Act + Assert
            collection.Page(10, 1).Should().BeNull();
        }

        [Fact]
        public void Page_OutOfBounds()
        {
            // Arrange
            var collection = Enumerable.Range(0, 3);

            // Act + Assert
            collection.Page(3, 2).Should().BeEmpty();
        }

        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(3, 3, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(9, 3, 3)]
        [InlineData(10, 3, 4)]
        public void Page_ValidPages(int numberOfElements, int pageSize, int expectedPages)
        {
            // Arrange
            var collection = Enumerable.Range(0, numberOfElements);

            // Act + Assert
            var currentElement = 0;

            for (int page = 1; page < expectedPages + 1; page++)
            {
                var result = collection.Page(pageSize, page);

                var expectedPageCount = page < expectedPages
                    ? pageSize
                    : numberOfElements - pageSize * (expectedPages - 1);

                result.Count().Should().Be(expectedPageCount);

                for (int i = 0; i < expectedPageCount; ++i)
                {
                    result.ElementAt(i).Should().Be(currentElement);
                    currentElement++;
                }
            }
        }

        [Theory]
        [InlineData(3, 0, 0)]
        [InlineData(3, -1, 1)]
        [InlineData(3, 1, -1)]
        public void Page_InvalidPage(int numberOfElements, int pageSize, int pageNumber)
        {
            // Arrange
            var collection = Enumerable.Range(0, numberOfElements);

            // Act + Assert
            Action action = () => collection.Page(pageSize, pageNumber);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(3, 3, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(9, 3, 3)]
        [InlineData(10, 3, 4)]
        public void PageWithTotal_ValidPages(int numberOfElements, int pageSize, int expectedPages)
        {
            // Arrange
            var collection = Enumerable.Range(0, numberOfElements);

            // Act + Assert
            var currentElement = 0;

            for (int page = 1; page < expectedPages + 1; page++)
            {
                var result = collection.PageWithTotal(pageSize, page);
                result.Should().NotBeNull();

                result.Total.Should().Be(collection.Count());
                result.PageNumber.Should().Be(page);
                result.PageSize.Should().Be(pageSize);
                result.Values.Should().NotBeNull();

                var expectedPageCount = page < expectedPages
                    ? pageSize
                    : numberOfElements - pageSize * (expectedPages - 1);

                result.Values.Count().Should().Be(expectedPageCount);

                for (int i = 0; i < expectedPageCount; ++i)
                {
                    result.Values.ElementAt(i).Should().Be(currentElement);
                    currentElement++;
                }
            }
        }

    }
}
