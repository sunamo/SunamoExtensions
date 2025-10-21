// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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