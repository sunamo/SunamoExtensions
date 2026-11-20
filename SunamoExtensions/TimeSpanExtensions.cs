namespace SunamoExtensions;

/// <summary>
/// Represents the time span extensions type.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// To nice string.
    /// </summary>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>The to nice string result.</returns>
    public static string ToNiceString(this TimeSpan timeSpan)
    {
        var result = timeSpan.ToString();
        var secondPostfix = ":00";
        if (result.EndsWith(secondPostfix)) result = result.Substring(0, result.Length - secondPostfix.Length);
        return result;
    }

    #region For easy copy from TimeSpanExtensionsSunamo.cs

    /// <summary>
    /// Total years.
    /// </summary>
    /// <param name="timespan">The timespan.</param>
    /// <returns>The total years result.</returns>
    public static int TotalYears(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 365.2425);
    }

    /// <summary>
    /// Total months.
    /// </summary>
    /// <param name="timespan">The timespan.</param>
    /// <returns>The total months result.</returns>
    public static int TotalMonths(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 30.436875);
    }

    #endregion
}
