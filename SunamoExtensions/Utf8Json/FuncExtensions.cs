namespace SunamoExtensions.Utf8Json;

/// <summary>
/// Extension methods for Func type (hack to avoid closure allocation)
/// </summary>
public static class FuncExtensions
{
    /// <summary>
    /// Converts a value to a Func that returns that value (hack to avoid closure allocation)
    /// </summary>
    /// <typeparam name="T">Type of the value</typeparam>
    /// <param name="value">Value to wrap</param>
    /// <returns>Func that returns the value</returns>
    public static Func<T> AsFunc<T>(this T value)
    {
        return new Func<T>(((object)value!).ReturnBox<T>);
    }

    /// <summary>
    /// Converts a reference type value to a Func that returns that value (faster version for reference types)
    /// </summary>
    /// <typeparam name="T">Reference type of the value</typeparam>
    /// <param name="value">Value to wrap</param>
    /// <returns>Func that returns the value</returns>
    public static Func<T> AsFuncFast<T>(this T value) where T : class
    {
        return new Func<T>(value.Return<T>);
    }

    /// <summary>
    /// Returns the value (helper method for reference types)
    /// </summary>
    static T Return<T>(this T value)
    {
        return value;
    }

    /// <summary>
    /// Returns the boxed value (helper method for value types)
    /// </summary>
    static T ReturnBox<T>(this object value)
    {
        return (T)value;
    }
}
