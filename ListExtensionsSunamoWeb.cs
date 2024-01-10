namespace SunamoExtensions;


public static partial class ListExtensions
{
    public static void AddRangeIfNotContain<T>(this IList<T> list, List<T> l)
    {
        foreach (var item in l)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }
    }


    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="list"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static List<string> LeadingRange(this List<string> list, IList<string> items)
    {
        for (int i = items.Count() - 1; i >= 0; i--)
        {
            list.Insert(0, items[i]);
        }

        return list;
    }

    public static List<T> Insert<T>(this IList<T> list, int dx, T item)
    {
        list.Insert(dx, item);
        return (List<T>)list;
    }
}
