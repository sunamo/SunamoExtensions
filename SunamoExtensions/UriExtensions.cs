namespace SunamoExtensions;

/// <summary>
/// Extension methods for Uri type
/// </summary>
public static class UriExtensions
{
    /// <summary>
    /// Returns the scheme delimiter for URI
    /// </summary>
    /// <param name="uri">URI instance (not used, allows extension method syntax)</param>
    /// <returns>Scheme delimiter string "://"</returns>
    public static string SchemeDelimiter(this Uri uri)
    {
        return "://";
    }
}
