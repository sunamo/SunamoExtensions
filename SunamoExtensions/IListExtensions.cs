namespace SunamoExtensions;

/// <summary>
/// Extension methods for IList and IEnumerable types
/// </summary>
public static class IListExtensions
{
    /// <summary>
    /// Swaps two elements in the list
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to modify</param>
    /// <param name="firstIndex">Index of first element</param>
    /// <param name="secondIndex">Index of second element</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex) //This check is not required but Partition function may make many calls so its for perf reason
            return;
        var temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }

    /// <summary>
    /// Returns the first element or null if the enumerable is empty
    /// </summary>
    /// <param name="enumerable">Enumerable to get first element from</param>
    /// <returns>First element or null</returns>
    public static object? FirstOrNull(this IEnumerable enumerable)
    {
        foreach (var item in enumerable) return item;
        return null;
    }

    /// <summary>
    /// Counts the number of elements in the enumerable
    /// </summary>
    /// <param name="enumerable">Enumerable to count</param>
    /// <returns>Number of elements</returns>
    public static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        foreach (var item in enumerable) count++;
        return count;
    }

    /// <summary>
    /// Sorts the list in ascending order
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to sort</param>
    public static void SortAsc<T>(this List<T> list)
    {
        list.Sort();
    }

    /// <summary>
    /// Takes the last N elements from the list
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="source">Source list</param>
    /// <param name="count">Number of elements to take</param>
    /// <returns>List containing the last N elements</returns>
    public static IList<T> TakeLast<T>(this IList<T> source, int count)
    {
        return source.Skip(Math.Max(0, source.Count - count)).ToList();
    }

    /// <summary>
    /// Filters elements based on a predicate
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the list</typeparam>
    /// <param name="source">Source list</param>
    /// <param name="predicate">Predicate to filter by</param>
    /// <returns>Filtered list</returns>
    public static IList<TSource> Where2<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        return source.ToList().Where(predicate).ToList();
    }

    /// <summary>
    /// Filters non-generic enumerable based on a predicate
    /// </summary>
    /// <param name="list">List to filter</param>
    /// <param name="predicate">Predicate to filter by</param>
    /// <returns>Filtered list of objects</returns>
    public static List<object> WhereNonGeneric(this IList list, Func<object, bool> predicate)
    {
        var result = new List<object>(Count(list));
        foreach (var item in list) result.Add(item);
        return result.Where(predicate).ToList();
    }

    /// <summary>
    /// Removes the last element from the list
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to modify</param>
    /// <returns>Modified list</returns>
    public static List<T> RemoveLast<T>(this IList<T> list)
    {
        list.RemoveAt(list.Count - 1);
        return list.ToList();
    }

    #region For easy copy from IListExtensionsShared64Sunamo.cs

    /// <summary>
    /// Removes element at specified index (creates new list)
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">Source list</param>
    /// <param name="index">Index of element to remove</param>
    /// <returns>New list with element removed</returns>
    public static IList<T> RemoveAt<T>(this IList<T> list, int index)
    {
        var resultList = list.ToList();
        resultList.RemoveAt(index);
        return resultList;
    }

    /// <summary>
    /// Dumps the list as a string representation
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to dump</param>
    /// <param name="operation">Operation name</param>
    /// <param name="args">Additional arguments</param>
    /// <returns>String representation</returns>
    /// <exception cref="Exception">This method is not implemented</exception>
    public static string DumpAsString<T>(this IList<T> list, string operation, object args)
    {
        throw new Exception("Nemůže tu být protože DumpListAsStringOneLine jsem přesouval do sunamo a tam už zůstane");
    }

    #region Cant be first because then have priority than LINQ method

    /// <summary>
    /// Returns the first element or null (renamed to avoid conflict with LINQ First)
    /// </summary>
    /// <param name="list">List to get first element from</param>
    /// <returns>First element or null</returns>
    public static object? First2(this IList list)
    {
        return FirstOrNull(list);
    }

    #endregion

    #endregion

    /// <summary>
    /// Returns the length of the list
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to get length of</param>
    /// <returns>Number of elements</returns>
    public static int Length2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    /// <summary>
    /// Counts elements in the list (renamed to avoid conflict with LINQ Count)
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to count</param>
    /// <returns>Number of elements</returns>
    public static int Count2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    /// <summary>
    /// Counts elements in non-generic list (renamed to avoid ambiguity)
    /// </summary>
    /// <param name="list">List to count</param>
    /// <returns>Number of elements</returns>
    public static int Count3(this IList list)
    {
        var count = 0;
        foreach (var item in list) count++;
        return count;
    }
}
