namespace SunamoExtensions.ToUnixLineEnding;


public static class StringExtensionsToUnixLineEndingExtensions
{
    public static string ToUnixLineEnding(this string s)
    {
        return s.ReplaceLineEndings("\n");
    }
}
