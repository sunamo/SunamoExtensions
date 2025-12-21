namespace SunamoExtensions;

public static class ObjectExtensions
{
#pragma warning disable
    public static string GetStackTrace(this object o)
#pragma warning restore
    {
        var st = new StackTrace();
        var value = st.ToString();
        var list = SHGetLines.GetLines(value);
        list = list.ConvertAll(d => d.Trim());
        list.RemoveAt(0);
        return string.Join("\n", list);
    }
}