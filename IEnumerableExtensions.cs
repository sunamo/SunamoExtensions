namespace SunamoExtensions;


public static partial class IListExtensions
{
    public static object FirstOrNull(this IEnumerable e)
    {
        foreach (var item in e)
        {
            return item;
        }

        return null;
    }

    public static int Count(this IEnumerable e)
    {
        int i = 0;

        foreach (var item in e)
        {
            i++;
        }

        return i;
    }

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

    // todo DumpAsStringHeaderArgs je ve SunamoShared který nemůži přidat do deps protože by to způsobilo chybu Cycle detected
    public static string DumpAsString<T>(this IList<T> ie, string operation, /*DumpAsStringHeaderArgs*/ object a)
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
    /// <summary>
    /// Cant be first because then have priority than LINQ method
    /// musel bych ke každé přidávat typový argument
    ///
    /// => Renamed to 2
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public static object First2(this IList e)
    {
        return FirstOrNull(e);
    }
    #endregion
    #endregion

    public static int Length2<T>(this IList<T> e)
    {
        return Enumerable.Count(e);
        //return CASE.Count(e);
    }

    /// <summary>
    /// přejmenoval jsem po převodu na global usings
    ///
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static int Count2<T>(this IList<T> e)
    {
        return Enumerable.Count(e);
        //return CASE.Count(e);
    }

    /// <summary>
    ///     Usage: in many places coz in Extensions is standard IList
    ///
    /// The call is ambiguous between the following methods or properties: 'IListExtensions.Count(System.Collections.IList)' and 'IListExtensions.Count(System.Collections.IList)'
    /// IListExtensions je pouze ve SunExt, i po pushi nového package furt to samé.
    /// přejmenováno na 3 a kdyžtak užívat Enumerable.Count
    ///
    ///
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public static int Count3(this IList e)
    {
        int i = 0;
        foreach (var item in e)
        {
            i++;
        }
        return i;
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
