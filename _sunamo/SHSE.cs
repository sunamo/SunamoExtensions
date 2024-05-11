using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoExtensions;
public class SHSE
{
    public static string FirstCharLower(string nazevPP)
    {
        if (nazevPP.Length < 2) return nazevPP;

        var sb = nazevPP.Substring(1);
        return nazevPP[0].ToString().ToLower() + sb;
    }

    public static List<string> GetLines(string p, bool autoTrim = false)
    {
        List<string> vr = new();
        StringReader sr = new(p);
        string f;
        while ((f = sr.ReadLine()) != null) vr.Add(f);

        if (autoTrim)
        {
            CASE.Trim(vr);
        }

        return vr;
    }

    public static string JoinNL(List<string> l)
    {
        StringBuilder sb = new();
        foreach (var item in l) sb.AppendLine(item);
        var r = string.Empty;
        r = sb.ToString();
        return r;
    }
}
