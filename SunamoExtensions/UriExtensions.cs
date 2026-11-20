#pragma warning disable IDE0060 // parameters kept because of the public API
// variables names: ok
namespace SunamoExtensions;

public static class UriExtensions
{
    public static string SchemeDelimiter(this Uri uri)
    {
        return "://";
    }
}
