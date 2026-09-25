namespace SunamoExtensions;

public static class ListExtensions
{
    public static void RemoveMany<T>(this IList<T> list, List<T> itemsToRemove)
    {
        foreach (var item in itemsToRemove) list.Remove(item);
    }

    public static void RemoveMany(this IList<string> list, List<string> itemsToRemove)
    {
        foreach (var item in itemsToRemove) list.Remove(item);
    }

    // WARNING: Do not use this for adding JS files - inserts in wrong order causing "function is not defined" errors
    private static List<T> Add2<T>(this IList<T> list, T item)
    {
        list.Add(item);
        return (List<T>)list;
    }

    public static void AddRangeIfNotContain<T>(this IList<T> list, List<T> itemsToAdd)
    {
        foreach (var item in itemsToAdd)
            if (!list.Contains(item))
                list.Add(item);
    }

    public static List<string> LeadingRange(this List<string> list, IList<string> items)
    {
        for (var i = items.Count() - 1; i >= 0; i--) list.Insert(0, items[i]);
        return list;
    }

    public static List<T> Insert<T>(this IList<T> list, int index, T item)
    {
        list.Insert(index, item);
        return (List<T>)list;
    }

    #region For easy copy from ListExtensionsSunamo.cs

    public static int Partition<T>(this IList<T> list, int start, int end, Random? rnd = null) where T : IComparable<T>
    {
        if (rnd != null)
            list.Swap(end, rnd.Next(start, end + 1));
        var pivot = list[end];
        var lastLow = start - 1;
        for (var i = start; i < end; i++)
            if (list[i].CompareTo(pivot) <= 0)
                list.Swap(i, ++lastLow);
        list.Swap(end, ++lastLow);
        return lastLow;
    }

    public static T NthOrderStatistic<T>(this IList<T> list, int n, Random? rnd = null) where T : IComparable<T>
    {
        return NthOrderStatistic(list, n, 0, list.Count - 1, rnd);
    }

    private static T NthOrderStatistic<T>(this IList<T> list, int n, int start, int end, Random? rnd)
        where T : IComparable<T>
    {
        while (true)
        {
            var pivotIndex = list.Partition(start, end, rnd);
            if (pivotIndex == n)
                return list[pivotIndex];
            if (n < pivotIndex)
                end = pivotIndex - 1;
            else
                start = pivotIndex + 1;
        }
    }

    // NOTE: Leading items should be always the last in code, Add items should be first in code
    public static List<string> Leading(this List<string> list, string item)
    {
        list.Insert(0, item);
        return list;
    }

    public static List<T> AddOrSet<T>(this IList<T> list, int index, T item)
    {
        if (list.Count > index)
            list[index] = item;
        else
            list.Add(item);
        return list.ToList();
    }

    #endregion
}
