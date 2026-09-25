namespace SunamoExtensions;

public static class DateTimeExtensions
{
    public static string ToLongTimeString(this DateTime dateTime)
        => $"{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";

    public static string ToShortTimeString(this DateTime dateTime)
        => $"{dateTime.Hour}:{dateTime.Minute}";

    public static string ToStringShortTimeNullable(this DateTime? dateTime)
    {
        if (dateTime.HasValue) return dateTime.Value.ToString("dd.M.yyyy");
        return string.Empty;
    }
}
