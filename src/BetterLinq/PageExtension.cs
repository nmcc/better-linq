using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterLinq
{
    /// <summary>
    /// Implements the pagination extension.
    /// </summary>
    public static class PageExtension
    {
        /// <summary>
        /// Paginates an enumeration.
        /// </summary>
        /// <typeparam name="T">The type of the items of the collection.</typeparam>
        /// <param name="collection">The collection to be paginated.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="pageNumber">The number of the page, starting at 1.</param>
        /// <returns>The enumerable with the paginated data.</returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, int pageSize, int pageNumber = 1)
        {
            if (collection == null)
            {
                return null;
            }

            if(pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 1");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 1");
            }

            return collection
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        /// <summary>
        /// Paginates an enumeration and returns the parameters used for paginating along with the total number of 
        /// elements in the entire collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to be paginated.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="pageNumber">The number of the page.</param>
        /// <returns>The paginated collection.</returns>
        /// <remarks>This method makes a call to LINQ's Count() method, which requires the
        /// collection to be iterated immediately.</remarks>
        public static PageWithTotal<T> PageWithTotal<T>(this IEnumerable<T> collection, int pageSize, int pageNumber = 1)
        {
            return new PageWithTotal<T>(
                values: collection.Page(pageSize, pageNumber),
                pageSize: pageSize,
                pageNumber: pageNumber,
                total: collection.Count());
        }
    }
}
