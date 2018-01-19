# Better LINQ

This project adds useful extensions to LINQ.

# Extensions

* `WithIndex<T>()` Iterates over a `IEnumerable<T>` and add the index within the iteration loop.
It's useful for situations where a `for` loop would be used to iterate over the collection.
* `Page<T>()` paginates a collection with for a given page size and page number
* `PageWithTotal<T>()` similar to `Page<T>()` but includes the extra data necessary to calculate pagination 
controls on a User Interface, namely: the total count of items, the page number and the page size.