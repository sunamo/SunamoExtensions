namespace SunamoExtensions;

public static class UriExtensions
{
#pragma warning disable
    public static string SchemeDelimiter(this Uri uri)
#pragma warning restore
    {
        return "://";
    }
}