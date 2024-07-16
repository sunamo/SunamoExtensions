//namespace SunamoExtensions._sunamo.SunamoExceptions;

internal class SH
{
    internal static string JoinNL(List<string> l)
    {
        StringBuilder sb = new();
        foreach (var item in l) sb.AppendLine(item);
        var r = string.Empty;
        r = sb.ToString();
        return r;
    }
    internal static List<string> SplitCharMore(string s, params char[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    internal static List<string> SplitMore(string s, params string[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    internal static List<string> SplitNone(string text, params string[] deli)
    {
        return text.Split(deli, StringSplitOptions.None).ToList();
    }
    internal static string NullToStringOrDefault(object n)
    {

        return n == null ? " " + Consts.nulled : AllStrings.space + n;
    }
    internal static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);
        return name;
    }

    internal static string FirstCharLower(string nazevPP)
    {
        if (nazevPP.Length < 2) return nazevPP;

        var sb = nazevPP.Substring(1);
        return nazevPP[0].ToString().ToLower() + sb;
    }

    internal static List<string> GetLines(string p, bool autoTrim = false)
    {
        List<string> vr = new();
        StringReader sr = new(p);
        string f;
        while ((f = sr.ReadLine()) != null) vr.Add(f);

        if (autoTrim)
        {
            vr = vr.ConvertAll(d => d.Trim());
        }

        return vr;
    }

}
