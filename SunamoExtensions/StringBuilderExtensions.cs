// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoExtensions;

public static class StringBuilderExtensions
{
    #region For easy copy

    public static void TrimEnd(this StringBuilder stringBuilder)
    {
        var length = stringBuilder.Length;
        for (var i = length - 1; i >= 0; i--)
            if (char.IsWhiteSpace(stringBuilder[i]))
                stringBuilder.Remove(i, 1);
            else
                break;
    }

    #endregion

    public static void AppendFormatLine(this StringBuilder stringBuilder, string test, params string[] args)
    {
        stringBuilder.AppendFormat(test, args);
        stringBuilder.AppendLine();
    }

    public static bool EndsWith(this StringBuilder stringBuilder, string test)
    {
        if (stringBuilder.Length < test.Length)
            return false;

        var end = stringBuilder.ToString(stringBuilder.Length - test.Length, test.Length);
        return end.Equals(test);
    }

    public static bool StartWith(this StringBuilder stringBuilder, string test)
    {
        if (stringBuilder.Length < test.Length)
            return false;

        var start = stringBuilder.ToString(0, test.Length);
        return start.Equals(test);
    }

    public static StringBuilder TrimEnd(this StringBuilder name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);
        return name;
    }


    public static StringBuilder TrimStart(this StringBuilder name, string ext)
    {
        while (name.StartWith(ext)) return name.Substring(ext.Length, name.Length - ext.Length);
        return name;
    }

    public static StringBuilder Substring(this StringBuilder input, int indexFrom = 1)
    {
        return input.Substring(indexFrom, input.Length - 1);
    }

    public static StringBuilder Substring(this StringBuilder input, int index, int length)
    {
        var subString = new StringBuilder();
        if (index + length - 1 >= input.Length || index < 0)
            throw new ArgumentOutOfRangeException("Index out of range!");
        var endIndex = index + length;
        for (var i = index; i < endIndex; i++) subString.Append(input[i]);
        return subString;
    }


    public static void TrimStart(this StringBuilder stringBuilder)
    {
        var length = stringBuilder.Length;
        for (var i = 0; i < length; i++)
            if (char.IsWhiteSpace(stringBuilder[i]))
                stringBuilder.Remove(i, 1);
            else
                break;
    }

    public static void Trim(this StringBuilder stringBuilder)
    {
        TrimEnd(stringBuilder);
        TrimStart(stringBuilder);
    }

    #region For easy copy from StringBuilderExtensions.cs

    public static bool Contains(this StringBuilder haystack, string needle)
    {
        return haystack.IndexOf(needle) != -1;
    }

    public static int IndexOf(this StringBuilder haystack, string needle)
    {
        if (haystack == null || needle == null)
            throw new ArgumentNullException();
        if (needle.Length == 0)
            return 0; //empty strings are everywhere!
        if (needle.Length == 1) //can't beat just spinning through for it
        {
            var count = needle[0];
            for (var idx = 0; idx != haystack.Length; ++idx)
                if (haystack[idx] == count)
                    return idx;
            return -1;
        }

        var message = 0;
        var i = 0;
        var temp = KMPTable(needle);
        while (message + i < haystack.Length)
            if (needle[i] == haystack[m + i])
            {
                if (i == needle.Length - 1)
                    return message == needle.Length ? -1 : message; //match -1 = failure to find conventional in .NET
                ++i;
            }
            else
            {
                message = message + i - temp[i];
                i = temp[i] > -1 ? temp[i] : 0;
            }

        return -1;
    }

    private static int[] KMPTable(string sought)
    {
        var table = new int[sought.Length];
        var pos = 2;
        var cnd = 0;
        table[0] = -1;
        table[1] = 0;
        while (pos < table.Length)
            if (sought[pos - 1] == sought[cnd])
                table[pos++] = ++cnd;
            else if (cnd > 0)
                cnd = table[cnd];
            else
                table[pos++] = 0;
        return table;
    }

    #endregion
}