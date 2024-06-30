namespace SunamoExtensions.ToUnixLineEnding;


public static partial class ToUnixLineEndingExtensions
{
    public static IList<string> ToUnixLineEnding(this IList<string> t)
    {
        for (int i = 0; i < t.Count; i++)
        {
            t[i] = t[i].ToUnixLineEnding();
        }
        return t;
    }
}

