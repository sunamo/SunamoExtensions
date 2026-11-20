#pragma warning disable IDE0060 // parameters kept because of the public API
namespace SunamoExtensions;

/// <summary>
/// Represents the object extensions type.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Get stack trace.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>The get stack trace result.</returns>
    public static string GetStackTrace(this object obj)
    {
        var stackTrace = new StackTrace();
        var value = stackTrace.ToString();
        var list = SHGetLines.GetLines(value);
        list = list.ConvertAll(line => line.Trim());
        list.RemoveAt(0);
        return string.Join("\n", list);
    }
}
