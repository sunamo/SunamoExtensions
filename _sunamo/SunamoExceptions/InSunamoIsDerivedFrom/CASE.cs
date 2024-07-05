using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoExtensions._sunamo.SunamoExceptions.InSunamoIsDerivedFrom;
internal class CASE
{
    internal static int Count(IEnumerable e)
    {
        if (e == null) return 0;

        var t = e.GetType();
        var tName = t.Name;
        // nevím jak to má .net core, zatím tu ThreadHelper nebudu přesouvat
        // if (ThreadHelper.NeedDispatcher(tName))
        // {
        //     int result = dCountSunExc(e);
        //     return result;
        // }

        if (e is IList) return (e as IList).Count;

        if (e is Array) return (e as Array).Length;

        var count = 0;

        foreach (var item in e) count++;

        return count;
    }

    internal static List<string> Trim(List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = l[i].Trim();

        return l;
    }
}
