// A part of the C# Language Syntactic Sugar suite.

using System.Collections.Generic;
using System;

namespace CLSS
{
  public static partial class IDictionaryMoveKey
  {
    /// <summary>
    /// Moves the value of an existing key to the new key if the new key did not
    /// already exist.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.
    /// </typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.
    /// </typeparam>
    /// <param name="dictionary">A dictionary with keys of type
    /// <typeparamref name="TKey"/> and values of type
    /// <typeparamref name="TValue"/>.</param>
    /// <param name="existingKey">The key of the value to move from.</param>
    /// <param name="newKey">The key of the value to move to.</param>
    /// <returns>The source dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is
    /// null.</exception>
    /// <exception cref="ArgumentException">An element with newKey already
    /// exists in the <see cref="IDictionary{TKey, TValue}"/></exception>
    public static IDictionary<TKey, TValue> MoveKey<TKey, TValue>(
      this IDictionary<TKey, TValue> dictionary,
      TKey existingKey,
      TKey newKey)
    {
      if (dictionary == null) throw new ArgumentNullException("source");
      if (dictionary.ContainsKey(newKey))
        throw new ArgumentException("The new key to move value to is not available.");
      var value = dictionary[existingKey];
      dictionary.Remove(existingKey);
      dictionary[newKey] = value;
      return dictionary;
    }

    /// <summary>
    /// Moves the value of an existing key to the new key if the new key did not
    /// already exist.
    /// </summary>
    /// <typeparam name="T">The type of
    /// <see cref="IDictionary{TKey, TValue}"/> to move key.</typeparam>
    /// <typeparam name="TKey">The type of the keys in the dictionary.
    /// </typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.
    /// </typeparam>
    /// <param name="dictionary">A dictionary with keys of type
    /// <typeparamref name="TKey"/> and values of type
    /// <typeparamref name="TValue"/>.</param>
    /// <param name="existingKey">The key of the value to move from.</param>
    /// <param name="newKey">The key of the value to move to.</param>
    /// <returns>The source dictionary.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is
    /// null.</exception>
    /// <exception cref="ArgumentException">An element with newKey already
    /// exists in the <see cref="IDictionary{TKey, TValue}"/></exception>
    public static T MoveKey<T, TKey, TValue>(this T dictionary,
      TKey existingKey,
      TKey newKey)
      where T : IDictionary<TKey, TValue>
    {
      if (dictionary == null) throw new ArgumentNullException("source");
      if (dictionary.ContainsKey(newKey))
        throw new ArgumentException("The new key to move value to is not available.");
      var value = dictionary[existingKey];
      dictionary.Remove(existingKey);
      dictionary[newKey] = value;
      return dictionary;
    }

    /// <summary>
    /// Moves the value of an existing key to the new key. If the
    /// <see cref="IDictionary{TKey, TValue}"/> already contains an element with
    /// <paramref name="newKey"/>, that value is assigned to the out argument
    /// <paramref name="conflictingValue"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.
    /// </typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.
    /// </typeparam>
    /// <param name="dictionary">A dictionary with keys of type
    /// <typeparamref name="TKey"/> and values of type
    /// <typeparamref name="TValue"/>.</param>
    /// <param name="existingKey">The key of the value to move from.</param>
    /// <param name="newKey">The key of the value to move to.</param>
    /// <param name="conflictingValue">When this method returns, the value
    /// previously associated with <paramref name="newKey"/>, if
    /// <paramref name="newKey"/> existed; otherwise, the default value for the
    /// type of the value parameter. This parameter is passed uninitialized.
    /// </param>
    /// <returns>true if the object that implements
    /// <see cref="IDictionary{TKey, TValue}"/> contains an element with
    /// <paramref name="newKey"/>; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is
    /// null.</exception>
    public static bool TryMoveKey<TKey, TValue>(
      this IDictionary<TKey, TValue> dictionary,
      TKey existingKey,
      TKey newKey,
      out TValue conflictingValue)
    {
      if (dictionary == null) throw new ArgumentNullException("source");
      conflictingValue = default(TValue);
      var hasConflict = dictionary.ContainsKey(newKey);
      if (hasConflict) conflictingValue = dictionary[existingKey];
      var value = dictionary[existingKey];
      dictionary.Remove(existingKey);
      dictionary[newKey] = value;
      return hasConflict;
    }
  }
}
