# CLSS.ExtensionMethods.IDictionary.MoveKey

### Problem

Changing the key of a key/value pair in any `IDictionary` collection is a 3-line process by default:

```
var value = dict[existingKey];
dict.Remove(existingKey);
dict[newKey] = value;
```

Checking for conflicting keys requires even more lines of code.

### Solution

`MoveKey` does this in 1 line:

```
using CLSS;

dict.MoveKey(existingKey, newKey);
```

In case the source `IDictionary` contains an element with `newKey`, `MoveKey` will throw an exception and the key move will not proceed.

With an implicit type invocation, it returns an `IDictionary<TKey, TValue>`. With an explicit type invocation, it returns the original collection type.

```
using CLSS;

var customSortedNames = new Dictionary<int, string>()
{
  [1] = "Ryan",
  [2] = "David",
  [3] = "Wendell"
};
numbers.MoveKey(2, 5); // returns IDictionary<int, string>
numbers.MoveKey<Dictionary<int, string>, int, string>(1, 6); // returns Dictionary<int, string>;
```

This package also provides the `TryMoveKey` method. In the case of new key conflict, `TryMoveKey` will proceed, assign the conflicting value that was previously associated to `newKey` to the 3rd argument and return true. `TryMoveKey` returns false if there is no conflict.

```
using CLSS;

if (dict.TryMoveKey(existingKey, newKey, out var conflictingValue))
{ /* Do something with conflictingValue */ }
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).