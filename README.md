# Extensions
A collection of extension methods


## IEnumerableExtensions

### Median
``` csharp
var source = new[] { 100, 200, 250, 300, 310 };
var median = source.Median();  // 250
```

### TakeEvery
``` csharp
var source = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
var group = source.TakeEvery(3).Skip(1).Take(1);  // { 3, 4, 5 }
```

### TakeUniqueSequence
``` csharp
var source = "Mississippi";
var group = source.TakeUniqueSequence();  // { 'M', 'i', 's', 'i', 's', 'i', 'p', 'i' }
```
