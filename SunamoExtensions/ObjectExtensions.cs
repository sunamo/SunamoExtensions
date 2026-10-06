#pragma warning disable IDE0060 // parametry zachovány kvůli veřejnému API
namespace SunamoExtensions;

public static class ObjectExtensions
{
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
