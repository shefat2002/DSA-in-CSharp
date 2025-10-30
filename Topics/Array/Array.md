# Array

### Syntax
```c#
type[] array_name;

string[] names;

names = new string[10];

$string[] names = new string[10];

int[] numbers = new int[] {1,2,3,4,5};
```
# Array Examples 

## 1. Array Declaration & Initialization

### Single-dimensional arrays
```c#
int[] numbers1 = new int[5];                    // Empty array of size 5
int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };  // Array with values
int[] numbers3 = { 1, 2, 3, 4, 5 };            // Shorthand initialization
```
### Multi-dimensional arrays
```c#
int[,] matrix = new int[2, 3];                  // 2D array
int[,,] cube = new int[2, 3, 4];               // 3D array
```
### Jagged arrays (array of arrays)
```c#
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
jagged[2] = new int[] { 6, 7, 8, 9 };
```

## 2. Basic Properties & Methods

### Properties
```c# Properties
int length = arr.Length;                    // 5
int rank = arr.Rank;                        // 1 (dimensions)
```
### Access elements
```c# 
int first = arr[0];                         // 1
int last = arr[arr.Length - 1];             // 5
```
### Modify elements
```c# 
arr[0] = 10;                               // {10, 2, 3, 4, 5}
```

## 3. Common Array Operations

### Iteration
```c#
int[] numbers = { 1, 2, 3, 4, 5 };

// For loop
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

// Foreach loop
foreach (int num in numbers)
{
    Console.WriteLine(num);
}
```

### Searching
```c#
int[] numbers = { 1, 2, 3, 4, 5 };

// Find index of element
int index = Array.IndexOf(numbers, 3);      // 2
int lastIndex = Array.LastIndexOf(numbers, 3); // 2

// Check if array contains value
bool contains = numbers.Contains(3);        // true

// Find element that matches condition
int found = Array.Find(numbers, x => x > 3); // 4
int[] allFound = Array.FindAll(numbers, x => x > 2); // {3, 4, 5}
```

### Sorting
```c#
int[] numbers = { 5, 3, 1, 4, 2 };

// Sort ascending
Array.Sort(numbers);                        // {1, 2, 3, 4, 5}

// Sort descending
Array.Sort(numbers);
Array.Reverse(numbers);                     // {5, 4, 3, 2, 1}

// Sort with custom comparer
Array.Sort(numbers, (a, b) => b.CompareTo(a)); // Descending
```

### Copying & Resizing
```c#
int[] source = { 1, 2, 3, 4, 5 };

// Copy to new array
int[] copy1 = new int[5];
Array.Copy(source, copy1, 5);

// Clone (shallow copy)
int[] copy2 = (int[])source.Clone();

// Resize array
Array.Resize(ref source, 10);              // Now size 10, new elements are 0

// Copy to existing array with offset
int[] destination = new int[10];
source.CopyTo(destination, 2);             // Copy to index 2
```

## 4. LINQ Operations with Arrays
```c#
using System.Linq;
int[] numbers = { 1, 2, 3, 4, 5 };
```
### Filtering
```c#
var even = numbers.Where(x => x % 2 == 0);  // {2, 4}
```
### Transformation
```c#
var squared = numbers.Select(x => x * x);   // {1, 4, 9, 16, 25}
```
### Aggregation
```c#
int sum = numbers.Sum();                    // 15
int max = numbers.Max();                    // 5
int min = numbers.Min();                    // 1
double avg = numbers.Average();             // 3
```
### Ordering
```c#
var ascending = numbers.OrderBy(x => x);    // {1, 2, 3, 4, 5}
var descending = numbers.OrderByDescending(x => x); // {5, 4, 3, 2, 1}
```
### Check conditions
```c#
bool allPositive = numbers.All(x => x > 0); // true
bool anyNegative = numbers.Any(x => x < 0); // false
```
### Conversion
```c#
List<int> list = numbers.ToList();
int[] array = list.ToArray();
```

## 5. Multi-dimensional Array Operations
```c#
// 2D array
int[,] matrix = new int[2, 3] { {1, 2, 3}, {4, 5, 6} };
```
### Get dimensions
```c#
int rows = matrix.GetLength(0);             // 2
int cols = matrix.GetLength(1);             // 3
```
### Iterate through 2D array
```c#
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
```


## 6. Useful Utility Methods
```c#
int[] numbers = { 1, 2, 3, 4, 5 };
```
### Clear elements
```c#
Array.Clear(numbers, 0, numbers.Length);    // All elements become 0
```
### Fill with value
```c#
Array.Fill(numbers, 10);                    // {10, 10, 10, 10, 10}
```
### Reverse array
```c#
Array.Reverse(numbers);                     // {5, 4, 3, 2, 1}
```
### Check if array is readonly
```c#
bool isReadOnly = numbers.IsReadOnly;       // false
```
### Binary search (requires sorted array)
```c#
Array.Sort(numbers);
int index = Array.BinarySearch(numbers, 3); // 2
```


## 7. Array Creation Shortcuts
### Create arrays with repeated values
```c#
int[] zeros = new int[5];                   // {0, 0, 0, 0, 0}
int[] ones = Enumerable.Repeat(1, 5).ToArray(); // {1, 1, 1, 1, 1}
```
### Create ranges
```c#
int[] range = Enumerable.Range(1, 5).ToArray(); // {1, 2, 3, 4, 5}
```
### Create empty arrays
```c#
int[] empty1 = new int[0];
int[] empty2 = Array.Empty<int>();
```

## 8. Common Patterns

### Initialize with default values
```c#
int[] arr = new int[5];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = i + 1;  // {1, 2, 3, 4, 5}
}
```
### Find min/max manually
```c#
int min = arr[0], max = arr[0];
foreach (int num in arr)
{
    if (num < min) min = num;
    if (num > max) max = num;
}
```
### Remove element by creating new array
```c#
int[] RemoveAt(int[] array, int index)
{
    int[] newArray = new int[array.Length - 1];
    Array.Copy(array, 0, newArray, 0, index);
    Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);
    return newArray;
}
```

# C# Array Operations Keywords with Descriptions

## Array Properties

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Length` | Gets total number of elements in all dimensions | `arr.Length` |
| `Rank` | Gets number of dimensions of the array | `arr.Rank` |
| `IsReadOnly` | Gets whether array is read-only (always false for arrays) | `arr.IsReadOnly` |
| `IsFixedSize` | Gets whether array has fixed size (always true) | `arr.IsFixedSize` |

## Array Creation & Initialization

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `new` | Creates new array instance | `new int[5]` |
| `{}` | Array initializer syntax | `{1, 2, 3}` |
| `Array.Empty<T>()` | Returns empty array singleton | `Array.Empty<int>()` |
| `Enumerable.Repeat` | Creates array with repeated values | `Enumerable.Repeat(1, 5).ToArray()` |
| `Enumerable.Range` | Creates array with number range | `Enumerable.Range(1, 5).ToArray()` |

## Element Access & Modification

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `[]` | Indexer access | `arr[0] = 5` |
| `GetValue()` | Gets value at specified position | `arr.GetValue(0)` |
| `SetValue()` | Sets value at specified position | `arr.SetValue(5, 0)` |

## Searching Operations

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Array.IndexOf()` | Finds first index of value | `Array.IndexOf(arr, 3)` |
| `Array.LastIndexOf()` | Finds last index of value | `Array.LastIndexOf(arr, 3)` |
| `Array.BinarySearch()` | Fast search in sorted array | `Array.BinarySearch(arr, 3)` |
| `Array.Find()` | Finds first element matching predicate | `Array.Find(arr, x => x > 2)` |
| `Array.FindLast()` | Finds last element matching predicate | `Array.FindLast(arr, x => x > 2)` |
| `Array.FindAll()` | Finds all elements matching predicate | `Array.FindAll(arr, x => x > 2)` |
| `Array.FindIndex()` | Finds index of first matching element | `Array.FindIndex(arr, x => x > 2)` |
| `Array.FindLastIndex()` | Finds index of last matching element | `Array.FindLastIndex(arr, x => x > 2)` |
| `Array.Exists()` | Checks if any element matches predicate | `Array.Exists(arr, x => x > 2)` |
| `Array.TrueForAll()` | Checks if all elements match predicate | `Array.TrueForAll(arr, x => x > 0)` |
| `Contains()` (LINQ) | Checks if array contains value | `arr.Contains(3)` |

## Sorting & Ordering

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Array.Sort()` | Sorts array in-place | `Array.Sort(arr)` |
| `Array.Reverse()` | Revers array order in-place | `Array.Reverse(arr)` |
| `OrderBy()` (LINQ) | Sorts ascending (returns new sequence) | `arr.OrderBy(x => x)` |
| `OrderByDescending()` (LINQ) | Sorts descending (returns new sequence) | `arr.OrderByDescending(x => x)` |
| `ThenBy()` (LINQ) | Secondary sort order | `arr.OrderBy(x => x).ThenBy(x => y)` |

## Copying & Resizing

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Array.Copy()` | Copies elements between arrays | `Array.Copy(src, dest, length)` |
| `CopyTo()` | Copies elements to another array | `src.CopyTo(dest, index)` |
| `Clone()` | Creates shallow copy | `(int[])arr.Clone()` |
| `Array.Resize()` | Changes array size | `Array.Resize(ref arr, 10)` |
| `ToArray()` (LINQ) | Converts to new array | `list.ToArray()` |

## Modification Operations

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Array.Clear()` | Sets range of elements to default values | `Array.Clear(arr, 0, arr.Length)` |
| `Array.Fill()` | Fills array with specific value | `Array.Fill(arr, 0)` |
| `Array.ConstrainedCopy()` | Copy that rolls back if exception occurs | `Array.ConstrainedCopy(src, 0, dest, 0, len)` |

## LINQ Operations (Require `using System.Linq`)

### Filtering
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Where()` | Filters elements based on predicate | `arr.Where(x => x > 2)` |
| `OfType<T>()` | Filters elements of specific type | `arr.OfType<int>()` |

### Transformation
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Select()` | Projects each element to new form | `arr.Select(x => x * 2)` |
| `SelectMany()` | Flattens collections | `arr.SelectMany(x => x)` |
| `Cast<T>()` | Casts elements to specified type | `arr.Cast<int>()` |

### Aggregation
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Sum()` | Calculates sum of elements | `arr.Sum()` |
| `Average()` | Calculates average of elements | `arr.Average()` |
| `Min()` | Finds minimum value | `arr.Min()` |
| `Max()` | Finds maximum value | `arr.Max()` |
| `Count()` | Counts elements | `arr.Count()` |
| `LongCount()` | Counts elements (returns long) | `arr.LongCount()` |
| `Aggregate()` | Applies accumulator function | `arr.Aggregate((a,b) => a + b)` |

### Element Operations
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `First()` | Gets first element | `arr.First()` |
| `FirstOrDefault()` | Gets first element or default | `arr.FirstOrDefault()` |
| `Last()` | Gets last element | `arr.Last()` |
| `LastOrDefault()` | Gets last element or default | `arr.LastOrDefault()` |
| `Single()` | Gets single element (throws if multiple) | `arr.Single(x => x == 1)` |
| `SingleOrDefault()` | Gets single element or default | `arr.SingleOrDefault(x => x == 1)` |
| `ElementAt()` | Gets element at specified index | `arr.ElementAt(2)` |
| `ElementAtOrDefault()` | Gets element at index or default | `arr.ElementAtOrDefault(2)` |

### Set Operations
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Distinct()` | Returns distinct elements | `arr.Distinct()` |
| `Union()` | Returns union of two sequences | `arr1.Union(arr2)` |
| `Intersect()` | Returns intersection of two sequences | `arr1.Intersect(arr2)` |
| `Except()` | Returns set difference | `arr1.Except(arr2)` |
| `Concat()` | Concatenates two sequences | `arr1.Concat(arr2)` |

### Partitioning
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Skip()` | Skips specified number of elements | `arr.Skip(2)` |
| `SkipWhile()` | Skips elements while condition is true | `arr.SkipWhile(x => x < 3)` |
| `Take()` | Takes specified number of elements | `arr.Take(3)` |
| `TakeWhile()` | Takes elements while condition is true | `arr.TakeWhile(x => x < 3)` |

### Quantifiers
| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Any()` | Checks if any elements exist | `arr.Any()` |
| `All()` | Checks if all elements satisfy condition | `arr.All(x => x > 0)` |
| `SequenceEqual()` | Checks if two sequences are equal | `arr1.SequenceEqual(arr2)` |

## Multi-dimensional Array Methods

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `GetLength()` | Gets length of specified dimension | `arr.GetLength(0)` |
| `GetLowerBound()` | Gets lower bound of dimension | `arr.GetLowerBound(0)` |
| `GetUpperBound()` | Gets upper bound of dimension | `arr.GetUpperBound(0)` |

## Conversion Methods

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `ToList()` (LINQ) | Converts to List<T> | `arr.ToList()` |
| `ToDictionary()` (LINQ) | Converts to Dictionary | `arr.ToDictionary(x => x)` |
| `ToLookup()` (LINQ) | Converts to Lookup | `arr.ToLookup(x => x)` |
| `AsEnumerable()` (LINQ) | Converts to IEnumerable | `arr.AsEnumerable()` |
| `AsQueryable()` (LINQ) | Converts to IQueryable | `arr.AsQueryable()` |

## Utility Methods

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `Array.ForEach()` | Performs action on each element | `Array.ForEach(arr, Console.WriteLine)` |
| `GetEnumerator()` | Gets enumerator for array | `arr.GetEnumerator()` |
| `Initialize()` | Initializes value type elements by calling default constructor | `arr.Initialize()` |

## Memory Operations (Advanced)

| Keyword/Method | Description | Example |
|---------------|-------------|---------|
| `AsSpan()` | Creates span over array | `arr.AsSpan()` |
| `AsMemory()` | Creates memory over array | `arr.AsMemory()` |
| `Buffer.BlockCopy()` | Copies bytes between arrays | `Buffer.BlockCopy(src, 0, dest, 0, bytes)` |\


