namespace SunamoExtensions;

public static class TimeSpanExtensions
{
    public static string ToNiceString(this TimeSpan timeSpan)
    {
        var result = timeSpan.ToString();
        var secondPostfix = ":00";
        if (result.EndsWith(secondPostfix)) result = result.Substring(0, result.Length - secondPostfix.Length);
        return result;
    }

    #region For easy copy from TimeSpanExtensionsSunamo.cs

    public static int TotalYears(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 365.2425);
    }

    public static int TotalMonths(this TimeSpan timespan)
    {
        return (int)(timespan.Days / 30.436875);
    }

    #endregion
}
