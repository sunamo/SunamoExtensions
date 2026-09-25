namespace SunamoExtensions;

/// <summary>
/// Extension methods for IDictionary interface
/// </summary>
public static class IDictionaryExtensions
{
    /// <summary>
    /// Adds a key-value pair to the dictionary only if the key doesn't already exist
    /// </summary>
    /// <typeparam name="T">Type of the dictionary key</typeparam>
    /// <typeparam name="U">Type of the dictionary value</typeparam>
    /// <param name="dictionary">Dictionary to add to</param>
    /// <param name="key">Key to add</param>
    /// <param name="value">Value to add</param>
    public static void AddIfNotExists<T, U>(this IDictionary<T, U> dictionary, T key, U value)
    {
        if (!dictionary.ContainsKey(key)) dictionary.Add(key, value);
    }
}