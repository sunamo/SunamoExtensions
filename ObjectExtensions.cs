
namespace SunamoExtensions;
public static class ObjectExtensions
{
    public static string GetStackTrace(this object o)
    {
        StackTrace st = new StackTrace();
        var v = st.ToString();
        var l = SHGetLines.GetLines(v);
        CASE.Trim(l);
        l.RemoveAt(0);
        return SHSunamoExceptions.JoinNL(l);
    }
}
