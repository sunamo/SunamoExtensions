namespace SunamoExtensions;

public static partial class TimeSpanExtensions
{
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
