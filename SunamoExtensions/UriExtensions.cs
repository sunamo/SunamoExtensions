#pragma warning disable IDE0060 // parametry zachovány kvůli veřejnému API
// variables names: ok
namespace SunamoExtensions;

public static class UriExtensions
{
    public static string SchemeDelimiter(this Uri uri)
    {
        return "://";
    }
}
