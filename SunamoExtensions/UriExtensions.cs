#pragma warning disable IDE0060 // parameters kept because of the public API
namespace SunamoExtensions;

/// <summary>
/// Represents the uri extensions type.
/// </summary>
public static class UriExtensions
{
    /// <summary>
    /// Scheme delimiter.
    /// </summary>
    /// <param name="uri">The uri.</param>
    /// <returns>The scheme delimiter result.</returns>
    public static string SchemeDelimiter(this Uri uri)
    {
        return "://";
    }
}
