using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterLinq
{
    /// <summary>
    /// Implements the group by aggregate extension
    /// </summary>
    public static class GroupByAggregateExtension
    {
        public static IEnumerable<IGrouping<TKey, TElement>> GroupByAggregate<TSource, TKey, TElement>(
            this IEnumerable<TSource> collection,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (collection == null)
            {
                return null;
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            if (elementSelector == null)
            {
                throw new ArgumentNullException(nameof(elementSelector));
            }

            throw new NotImplementedException();
        }
    }
}
