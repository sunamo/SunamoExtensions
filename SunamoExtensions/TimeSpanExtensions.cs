namespace SunamoExtensions;

/// <summary>
/// Extension methods for TimeSpan type
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Converts TimeSpan to a nice string format by removing trailing ":00" seconds
    /// </summary>
    /// <param name="timeSpan">TimeSpan to convert</param>
    /// <returns>Formatted string without trailing seconds if they are zero</returns>
    public static string ToNiceString(this TimeSpan timeSpan)
    {
        var result = timeSpan.ToString();
        var secondPostfix = ":00";
        if (result.EndsWith(secondPostfix)) result = result.Substring(0, result.Length - secondPostfix.Length);
        return result;
    }

    #region For easy copy from TimeSpanExtensionsSunamo.cs

    /// <summary>
    /// Calculates the total number of years in the TimeSpan
    /// </summary>
    /// <param name="timespan">TimeSpan to calculate years from</param>
    /// <returns>Total number of years (rounded down)</returns>
    public static int TotalYears(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 365.2425);
    }

    /// <summary>
    /// Calculates the total number of months in the TimeSpan
    /// </summary>
    /// <param name="timespan">TimeSpan to calculate months from</param>
    /// <returns>Total number of months (rounded down)</returns>
    public static int TotalMonths(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 30.436875);
    }

    #endregion
}