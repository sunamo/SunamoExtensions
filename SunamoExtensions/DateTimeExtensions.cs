namespace SunamoExtensions;

/// <summary>
/// Represents the date time extensions type.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// To long time string.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The to long time string result.</returns>
    public static string ToLongTimeString(this DateTime dateTime)
        => $"{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";

    /// <summary>
    /// To short time string.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The to short time string result.</returns>
    public static string ToShortTimeString(this DateTime dateTime)
        => $"{dateTime.Hour}:{dateTime.Minute}";

    /// <summary>
    /// To string short time nullable.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The to string short time nullable result.</returns>
    public static string ToStringShortTimeNullable(this DateTime? dateTime)
    {
        if (dateTime.HasValue) return dateTime.Value.ToString("dd.M.yyyy");
        return string.Empty;
    }
}
