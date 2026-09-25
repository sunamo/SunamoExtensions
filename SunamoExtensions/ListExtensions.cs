namespace SunamoExtensions;

/// <summary>
/// Extension methods for List type
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Removes multiple items from the list
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to remove items from</param>
    /// <param name="itemsToRemove">Items to remove</param>
    public static void RemoveMany<T>(this IList<T> list, List<T> itemsToRemove)
    {
        foreach (var item in itemsToRemove) list.Remove(item);
    }

    /// <summary>
    /// Removes multiple string items from the list
    /// </summary>
    /// <param name="list">List to remove items from</param>
    /// <param name="itemsToRemove">Items to remove</param>
    public static void RemoveMany(this IList<string> list, List<string> itemsToRemove)
    {
        foreach (var item in itemsToRemove) list.Remove(item);
    }

    /// <summary>
    /// Adds an item to the list and returns the modified list
    /// WARNING: Do not use this for adding JS files - inserts in wrong order causing "function is not defined" errors
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to add to</param>
    /// <param name="item">Item to add</param>
    /// <returns>Modified list</returns>
    private static List<T> Add2<T>(this IList<T> list, T item)
    {
        list.Add(item);
        return (List<T>)list;
    }

    /// <summary>
    /// Adds multiple items to the list only if they don't already exist
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to add items to</param>
    /// <param name="itemsToAdd">Items to add</param>
    public static void AddRangeIfNotContain<T>(this IList<T> list, List<T> itemsToAdd)
    {
        foreach (var item in itemsToAdd)
            if (!list.Contains(item))
                list.Add(item);
    }

    /// <summary>
    /// Inserts items at the beginning of the list (direct edit)
    /// </summary>
    /// <param name="list">List to modify</param>
    /// <param name="items">Items to insert at the beginning</param>
    /// <returns>Modified list</returns>
    public static List<string> LeadingRange(this List<string> list, IList<string> items)
    {
        for (var i = items.Count() - 1; i >= 0; i--) list.Insert(0, items[i]);
        return list;
    }

    /// <summary>
    /// Inserts an item at the specified index
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to insert into</param>
    /// <param name="index">Index to insert at</param>
    /// <param name="item">Item to insert</param>
    /// <returns>Modified list</returns>
    public static List<T> Insert<T>(this IList<T> list, int index, T item)
    {
        list.Insert(index, item);
        return (List<T>)list;
    }

    #region For easy copy from ListExtensionsSunamo.cs

    /// <summary>
    /// Partitions the given list around a pivot element such that all elements on left of pivot are &lt;= pivot
    /// and the ones at the right are &gt; pivot. This method can be used for sorting, N-order statistics such as
    /// median finding algorithms.
    /// Pivot is selected randomly if random number generator is supplied else its selected as last element in the list.
    /// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 171
    /// </summary>
    /// <typeparam name="T">Type of elements that implements IComparable</typeparam>
    /// <param name="list">List to partition (must be List due to working with indexes)</param>
    /// <param name="start">Start index</param>
    /// <param name="end">End index</param>
    /// <param name="rnd">Optional random number generator for pivot selection</param>
    /// <returns>Index of the pivot element after partitioning</returns>
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

    /// <summary>
    /// Returns Nth smallest element from the list. Here n starts from 0 so that n=0 returns minimum, n=1 returns 2nd smallest element etc.
    /// Note: specified list would be mutated in the process.
    /// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 216
    /// </summary>
    /// <typeparam name="T">Type of elements that implements IComparable</typeparam>
    /// <param name="list">List to find Nth order statistic in</param>
    /// <param name="n">Order statistic to find (0-based, 0 = minimum)</param>
    /// <param name="rnd">Optional random number generator</param>
    /// <returns>Nth smallest element</returns>
    public static T NthOrderStatistic<T>(this IList<T> list, int n, Random? rnd = null) where T : IComparable<T>
    {
        return NthOrderStatistic(list, n, 0, list.Count - 1, rnd);
    }

    /// <summary>
    /// Internal helper for NthOrderStatistic
    /// </summary>
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

    /// <summary>
    /// Inserts an item at the beginning of the list
    /// NOTE: Leading items should be always the last in code, Add items should be first in code
    /// </summary>
    /// <param name="list">List to modify</param>
    /// <param name="item">Item to insert at the beginning</param>
    /// <returns>Modified list</returns>
    public static List<string> Leading(this List<string> list, string item)
    {
        list.Insert(0, item);
        return list;
    }

    /// <summary>
    /// Adds or sets an item at the specified index (sets if index exists, adds if not)
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    /// <param name="list">List to modify</param>
    /// <param name="index">Index to add or set at</param>
    /// <param name="item">Item to add or set</param>
    /// <returns>Modified list</returns>
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