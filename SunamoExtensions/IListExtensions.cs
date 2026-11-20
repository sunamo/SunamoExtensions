namespace SunamoExtensions;

/// <summary>
/// Represents the i list extensions type.
/// </summary>
public static class IListExtensions
{
    /// <summary>
    /// Swap t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="firstIndex">The first index.</param>
    /// <param name="secondIndex">The second index.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex) //This check is not required but Partition function may make many calls so its for perf reason
            return;
        var temporaryValue = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temporaryValue;
    }

    /// <summary>
    /// First or null.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The first or null result.</returns>
    public static object? FirstOrNull(this IEnumerable enumerable)
    {
        foreach (var item in enumerable) return item;
        return null;
    }

    /// <summary>
    /// Count.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The count result.</returns>
    public static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        foreach (var item in enumerable) count++;
        return count;
    }

    /// <summary>
    /// Sort asc t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    public static void SortAsc<T>(this List<T> list)
    {
        list.Sort();
    }

    /// <summary>
    /// Take last t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="count">The count.</param>
    /// <returns>The take last t result.</returns>
    public static IList<T> TakeLast<T>(this IList<T> source, int count)
    {
        return source.Skip(Math.Max(0, source.Count - count)).ToList();
    }

    /// <summary>
    /// Where 2 t source.
    /// </summary>
    /// <typeparam name="TSource">The type TSource.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns>The where 2 t source result.</returns>
    public static IList<TSource> Where2<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        return source.ToList().Where(predicate).ToList();
    }

    /// <summary>
    /// Where non generic.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns>The where non generic result.</returns>
    public static List<object> WhereNonGeneric(this IList list, Func<object, bool> predicate)
    {
        var result = new List<object>(Count(list));
        foreach (var item in list) result.Add(item);
        return result.Where(predicate).ToList();
    }

    /// <summary>
    /// Remove last t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The remove last t result.</returns>
    public static List<T> RemoveLast<T>(this IList<T> list)
    {
        list.RemoveAt(list.Count - 1);
        return list.ToList();
    }

    #region For easy copy from IListExtensionsShared64Sunamo.cs

    /// <summary>
    /// Remove at t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="index">The index.</param>
    /// <returns>The remove at t result.</returns>
    public static IList<T> RemoveAt<T>(this IList<T> list, int index)
    {
        var resultList = list.ToList();
        resultList.RemoveAt(index);
        return resultList;
    }

    /// <summary>
    /// Dump as string t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="operation">The operation.</param>
    /// <param name="args">The args.</param>
    /// <returns>The dump as string t result.</returns>
    public static string DumpAsString<T>(this IList<T> list, string operation, object args)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will remain there");
    }

    #region Cant be first because then have priority than LINQ method

    /// <summary>
    /// First 2.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The first 2 result.</returns>
    public static object? First2(this IList list)
    {
        return FirstOrNull(list);
    }

    #endregion

    #endregion

    /// <summary>
    /// Length 2 t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The length 2 t result.</returns>
    public static int Length2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    /// <summary>
    /// Count 2 t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The count 2 t result.</returns>
    public static int Count2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    /// <summary>
    /// Count 3.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The count 3 result.</returns>
    public static int Count3(this IList list)
    {
        var count = 0;
        foreach (var item in list) count++;
        return count;
    }
}
