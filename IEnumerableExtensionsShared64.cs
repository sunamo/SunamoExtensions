namespace SunamoExtensions;


/// <summary>
///     je ve sunamo (ale i s NS sunamo jako v�echny extensions t��dy tam) a extensions (bez NS). proto zde ten NS mus�m
///     nechat
/// </summary>
public static partial class IListExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap<T>(this IList<T> list, int dx1, int dx2)
    {
        if (dx1 == dx2)   //This check is not required but Partition function may make many calls so its for perf reason
            return;
        var temp = list[dx1];
        list[dx1] = list[dx2];
        list[dx2] = temp;
    }
    #region from IListExtensionsShared64.cs

    //public static object FirstOrNull(this IList e)
    //{
    //    if (e.Count > 0)
    //    {
    //        // Here cant call CA.ToList because in FirstOrNull is called in CA.ToList => StackOverflowException
    //        //System.Collections.Generic.List<object> c = CAThread.ToList(e);
    //        //return c.FirstOrDefault();

    //        return e.First2();
    //    }

    //    return null;
    //}



    #endregion
}
