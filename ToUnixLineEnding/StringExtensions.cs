
namespace SunamoExtensions.ToUnixLineEnding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class StringExtensionsToUnixLineEndingExtensions
{
    public static string ToUnixLineEnding(this string s)
    {
        return s.ReplaceLineEndings("\n");
    }
}



