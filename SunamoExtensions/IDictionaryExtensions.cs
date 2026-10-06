namespace SunamoExtensions;

public static class IDictionaryExtensions
{
    public static void AddIfNotExists<T, U>(this IDictionary<T, U> dictionary, T key, U value)
    {
        if (!dictionary.ContainsKey(key)) dictionary.Add(key, value);
    }
}
