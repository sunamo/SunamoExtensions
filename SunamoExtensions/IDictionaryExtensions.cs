namespace SunamoExtensions;

/// <summary>
/// Represents the i dictionary extensions type.
/// </summary>
public static class IDictionaryExtensions
{
    /// <summary>
    /// Add if not exists t u.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The add if not exists t u result.</returns>
    public static void AddIfNotExists<T, U>(this IDictionary<T, U> dictionary, T key, U value)
    {
        if (!dictionary.ContainsKey(key)) dictionary.Add(key, value);
    }
}
