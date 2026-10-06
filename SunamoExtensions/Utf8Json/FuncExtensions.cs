namespace SunamoExtensions.Utf8Json;

public static class FuncExtensions
{
    // hack to avoid closure allocation
    public static Func<T> AsFunc<T>(this T value)
    {
        return new Func<T>(((object)value!).ReturnBox<T>);
    }

    // faster version for reference types
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
