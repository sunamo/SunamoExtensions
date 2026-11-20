namespace SunamoExtensions.Utf8Json;

/// <summary>
/// Represents the func extensions type.
/// </summary>
public static class FuncExtensions
{
    // hack to avoid closure allocation
    /// <summary>
    /// As func t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The as func t result.</returns>
    public static Func<T> AsFunc<T>(this T value)
    {
        return new Func<T>(((object)value!).ReturnBox<T>);
    }

    // faster version for reference types
    /// <summary>
    /// As func fast t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The as func fast t result.</returns>
    public static Func<T> AsFuncFast<T>(this T value) where T : class
    {
        return new Func<T>(value.Return<T>);
    }

    static T Return<T>(this T value)
    {
        return value;
    }

    static T ReturnBox<T>(this object value)
    {
        return (T)value;
    }
}
