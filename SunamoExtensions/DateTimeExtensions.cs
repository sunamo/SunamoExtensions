namespace SunamoExtensions;

/// <summary>
/// Extension methods for DateTime type
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Converts DateTime to long time string format (HH:mm:ss)
    /// </summary>
    /// <param name="dateTime">DateTime to convert</param>
    /// <returns>Time string in format "HH:mm:ss"</returns>
    public static string ToLongTimeString(this DateTime dateTime)
    {
        return dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
    }

    /// <summary>
    /// Converts DateTime to short time string format (HH:mm)
    /// </summary>
    /// <param name="dateTime">DateTime to convert</param>
    /// <returns>Time string in format "HH:mm"</returns>
    public static string ToShortTimeString(this DateTime dateTime)
    {
        return dateTime.Hour + ":" + dateTime.Minute;
    }

    /// <summary>
    /// Converts nullable DateTime to short date string, returns empty string if null
    /// </summary>
    /// <param name="dateTime">Nullable DateTime to convert</param>
    /// <returns>Date string in format "dd.M.yyyy" or empty string if null</returns>
    public static string ToStringShortTimeNullable(this DateTime? dateTime)
    {
        if (dateTime.HasValue) return dateTime.Value.ToString("dd.M.yyyy");
        return string.Empty;
    }
}
