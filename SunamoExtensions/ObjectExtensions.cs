namespace SunamoExtensions;

public static class ObjectExtensions
{
#pragma warning disable
    public static string GetStackTrace(this object o)
#pragma warning restore
    {
        var st = new StackTrace();
        var v = st.ToString();
        var l = SHGetLines.GetLines(v);
        l = l.ConvertAll(d => d.Trim());
        l.RemoveAt(0);
        return string.Join("\n", l);
    }
}