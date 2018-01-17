using System.Collections.Generic;

namespace BetterLinq
{
    /// <summary>
    /// Represents a paginated collection with the relevant data that was used to paginate.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection.</typeparam>
    public sealed class PageWithTotal<T>
    {
        /// <summary>
        /// Initializes an instance of this class
        /// </summary>
        /// <param name="values">The paginated collection</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="pageNumber">The number of the page</param>
        /// <param name="total">The total count of values in the entire collection.</param>
        public PageWithTotal(IEnumerable<T> values, int pageSize, int pageNumber, int total)
        {
            this.Values = values;
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
            this.Total = total;
        }

        /// <summary>
        /// The count of elements of the complete enumeration.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// The size of the page
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// The number of the page
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The paginated collection
        /// </summary>
        public IEnumerable<T> Values { get; }
    }
}
