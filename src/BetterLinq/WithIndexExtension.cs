using System;
using System.Collections.Generic;
using System.Text;

namespace BetterLinq
{
    public static class WithIndexExtension
    {
        /// <summary>
        /// Adds the index of each item withing the collection
        /// </summary>
        /// <typeparam name="T">The type of the element</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>An enumeration of an object containing the index and the corresponding element</returns>
        public static IEnumerable<Indexed<T>> WithIndex<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                yield break;
            }

            var i = 0;
            foreach (var item in collection)
            {
                yield return new Indexed<T>(i, item);
                i++;
            }
        }
    }
}
