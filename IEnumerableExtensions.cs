public static partial class IListExtensions
{
    #region For easy copy from IListExtensionsShared64Sunamo.cs
    /// <summary>
    /// Must be written with type parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <param name="dx"></param>
    /// <returns></returns>
    public static IList<T> RemoveAt<T>(this IList<T> t, int dx)
    {
        var l = t.ToList();
        l.RemoveAt(dx);
        return l;
    }

    public static string DumpAsString<T>(this IList<T> ie, string operation, DumpAsStringHeaderArgs a)
    {
        throw new Exception("Nemůže tu být protože DumpListAsStringOneLine jsem přesouval do sunamo a tam už zůstane");
        //
        //return RHSE.DumpListAsStringOneLine(operation, ie, a);
    }

    #region Must be two coz in some projects is not Dispatcher
    //public static object FirstOrNull(this IList e)
    //{
    //    return se.IListExtensions.FirstOrNull(e);
    //}

    #region Cant be first because then have priority than LINQ method
    //public static object First(this IList e)
    //{
    //    return FirstOrNull(e);
    //}
    #endregion
    #endregion

    public static int Length<T>(this IList<T> e)
    {
        return Enumerable.Count(e);
        //return CASE.Count(e);
    }

    // přejmenoval jsem po převodu na global usings
    public static int Count2<T>(this IList<T> e)
    {
        return Enumerable.Count(e);
        //return CASE.Count(e);
    }
    #endregion

    public static void SortAsc<T>(this List<T> c)
    {
        c.Sort();
    }

    public static IList<T> TakeLast<T>(this IList<T> source, int N)
    {
        return source.Skip(Math.Max(0, source.Count - N)).ToList();
    }

    public static IList<TSource> Where2<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        //source.ToList().Where(predicate); - StackOverflowExtension
        //return new List<TSource>(source).Where(predicate) ;
        return source.ToList().Where(predicate).ToList();
    }

    public static List<object> WhereNonGeneric(this IList enu, Func<object, bool> predicate)
    {
        List<object> o = new List<object>(CASE.Count(enu));
        foreach (var item in enu)
        {
            o.Add(item);
        }

        return o.Where(predicate).ToList();
    }

    /// <summary>
    /// Not direct edit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static List<T> RemoveLast<T>(this IList<T> t)
    {
        t.RemoveAt(t.Count - 1);
        return t.ToList();
    }
}
