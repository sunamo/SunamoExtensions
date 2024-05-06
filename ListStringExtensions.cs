using SunamoStringGetLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoExtensions;
public static class ListStringExtensions
{
    public static void InsertMultilineString(this List<string> l, int dx, string toInsert)
    {
        var lines = SHGetLines.GetLines(toInsert);

        for (int i = lines.Count - 1; i >= 0; i--)
        {
            l.Insert(dx, lines[i]);
        }
    }
}
