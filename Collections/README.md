# Collections

### SizedQueue<T>
A fixed sized queue that automatically dequeues the oldest element when the capacity becomes full. One scenario is when you need to get the last x number of elements and do not care about older elements.

Example:
```
var recentlyOpenedFiles = new SizedQueue<string>(10);
```

---
### TupleList<T1, T2>
### TupleList<T1, T2, T3>
### TupleList<T1, T2, T3, T4>
### TupleList<T1, T2, T3, T4, T5>
Lets you create a collection of Tuple objects in a simpler, more readable way. 

Example 1:
```
var tuples = new TupleList<int, string, double, bool>
{
    { 0, "Apple", 2.56, true },
    { 1, "Orange", 3.99, false },
    { 2, "Banana", .99, true },
};
```

As opposed to:
```
var tuples = new List<Tuple<int, string, double, bool>>
{
    Tuple.Create(0, "Apple", 2.56, true),
    Tuple.Create(1, "Orange", 3.99, false),
    Tuple.Create(2, "Banana", .99, true),
};
```

The last values can be skipped to default objects.

Example 2:
```
var tuples3 = new TupleList<int, string, double, bool>
{
    { 0, "Apple", 2.56, true },
    { 1, "Orange", 3.99 },  // default(T4) will be added..
    { 2, "Banana", .99, true },
};
```

> This is a custom implementation of the Collection Initializer (a language feature).

