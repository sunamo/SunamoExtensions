namespace SunamoExtensions;

/// <summary>
/// Extension methods for Object type
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Gets the current stack trace as a formatted string
    /// </summary>
    /// <param name="obj">Object instance (not used, allows extension method syntax)</param>
    /// <returns>Formatted stack trace string with each frame on a new line</returns>
    public static string GetStackTrace(this object obj)
    {
        var st = new StackTrace();
        var value = st.ToString();
        var list = SHGetLines.GetLines(value);
        list = list.ConvertAll(line => line.Trim());
        list.RemoveAt(0);
        return string.Join("\n", list);
    }
}
