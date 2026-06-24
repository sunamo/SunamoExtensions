namespace SunamoExtensions;

public static class IListExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex) //This check is not required but Partition function may make many calls so its for perf reason
            return;
        var temporaryValue = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temporaryValue;
    }

    public static object? FirstOrNull(this IEnumerable enumerable)
    {
        foreach (var item in enumerable) return item;
        return null;
    }

    public static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        foreach (var item in enumerable) count++;
        return count;
    }

    public static void SortAsc<T>(this List<T> list)
    {
        list.Sort();
    }

    public static IList<T> TakeLast<T>(this IList<T> source, int count)
    {
        return source.Skip(Math.Max(0, source.Count - count)).ToList();
    }

    public static IList<TSource> Where2<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        return source.ToList().Where(predicate).ToList();
    }

    public static List<object> WhereNonGeneric(this IList list, Func<object, bool> predicate)
    {
        var result = new List<object>(Count(list));
        foreach (var item in list) result.Add(item);
        return result.Where(predicate).ToList();
    }

    public static List<T> RemoveLast<T>(this IList<T> list)
    {
        list.RemoveAt(list.Count - 1);
        return list.ToList();
    }

    #region For easy copy from IListExtensionsShared64Sunamo.cs

    public static IList<T> RemoveAt<T>(this IList<T> list, int index)
    {
        var resultList = list.ToList();
        resultList.RemoveAt(index);
        return resultList;
    }

    public static string DumpAsString<T>(this IList<T> list, string operation, object args)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will remain there");
    }

    #region Cant be first because then have priority than LINQ method

    public static object? First2(this IList list)
    {
        return FirstOrNull(list);
    }

    #endregion

    #endregion

    public static int Length2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    public static int Count2<T>(this IList<T> list)
    {
        return Enumerable.Count(list);
    }

    public static int Count3(this IList list)
    {
        var count = 0;
        foreach (var item in list) count++;
        return count;
    }
}
