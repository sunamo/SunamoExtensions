public static partial class IListExtensions
{
    public static void Swap<T>(this IList<T> l, int index1, int index2)
    {
        var d = l[index1];
        l[index1] = l[index2];
        l[index2] = d;
    }
}
