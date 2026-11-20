namespace SunamoExtensions;

/// <summary>
/// Represents the string builder extensions type.
/// </summary>
public static class StringBuilderExtensions
{
    #region For easy copy

    /// <summary>
    /// Trim end.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
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

    /// <summary>
    /// Append format line.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The args.</param>
    public static void AppendFormatLine(this StringBuilder stringBuilder, string format, params string[] args)
    {
        stringBuilder.AppendFormat(format, args);
        stringBuilder.AppendLine();
    }

    /// <summary>
    /// Ends with.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="value">The value.</param>
    /// <returns>The ends with result.</returns>
    public static bool EndsWith(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder.Length < value.Length)
            return false;

        var end = stringBuilder.ToString(stringBuilder.Length - value.Length, value.Length);
        return end.Equals(value);
    }

    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="value">The value.</param>
    /// <returns>The start with result.</returns>
    public static bool StartWith(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder.Length < value.Length)
            return false;

        var start = stringBuilder.ToString(0, value.Length);
        return start.Equals(value);
    }

    /// <summary>
    /// Trim end.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="suffix">The suffix.</param>
    /// <returns>The trim end result.</returns>
    public static StringBuilder TrimEnd(this StringBuilder stringBuilder, string suffix)
    {
        while (stringBuilder.EndsWith(suffix)) return stringBuilder.Substring(0, stringBuilder.Length - suffix.Length);
        return stringBuilder;
    }

    /// <summary>
    /// Trim start.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>The trim start result.</returns>
    public static StringBuilder TrimStart(this StringBuilder stringBuilder, string prefix)
    {
        while (stringBuilder.StartWith(prefix)) return stringBuilder.Substring(prefix.Length, stringBuilder.Length - prefix.Length);
        return stringBuilder;
    }

    /// <summary>
    /// Substring.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="indexFrom">The index from.</param>
    /// <returns>The substring result.</returns>
    public static StringBuilder Substring(this StringBuilder stringBuilder, int indexFrom = 1)
    {
        return stringBuilder.Substring(indexFrom, stringBuilder.Length - 1);
    }

    /// <summary>
    /// Substring.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="index">The index.</param>
    /// <param name="length">The length.</param>
    /// <returns>The substring result.</returns>
    public static StringBuilder Substring(this StringBuilder stringBuilder, int index, int length)
    {
        var subString = new StringBuilder();
        if (index + length - 1 >= stringBuilder.Length || index < 0)
            throw new ArgumentOutOfRangeException("Index out of range!");
        var endIndex = index + length;
        for (var i = index; i < endIndex; i++) subString.Append(stringBuilder[i]);
        return subString;
    }

    /// <summary>
    /// Trim start.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    public static void TrimStart(this StringBuilder stringBuilder)
    {
        var length = stringBuilder.Length;
        for (var i = 0; i < length; i++)
            if (char.IsWhiteSpace(stringBuilder[i]))
                stringBuilder.Remove(i, 1);
            else
                break;
    }

    /// <summary>
    /// Trim.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    public static void Trim(this StringBuilder stringBuilder)
    {
        TrimEnd(stringBuilder);
        TrimStart(stringBuilder);
    }

    #region For easy copy from StringBuilderExtensions.cs

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
    public static bool Contains(this StringBuilder stringBuilder, string value)
    {
        return stringBuilder.IndexOf(value) != -1;
    }

    /// <summary>
    /// Index of.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="value">The value.</param>
    /// <returns>The index of result.</returns>
    public static int IndexOf(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder == null || value == null)
            throw new ArgumentNullException();
        if (value.Length == 0)
            return 0; //empty strings are everywhere!
        if (value.Length == 1) //can't beat just spinning through for it
        {
            var searchChar = value[0];
            for (var index = 0; index != stringBuilder.Length; ++index)
                if (stringBuilder[index] == searchChar)
                    return index;
            return -1;
        }

        var currentIndex = 0;
        var patternIndex = 0;
        var kmpTable = KMPTable(value);
        while (currentIndex + patternIndex < stringBuilder.Length)
            if (value[patternIndex] == stringBuilder[currentIndex + patternIndex])
            {
                if (patternIndex == value.Length - 1)
                    return currentIndex == value.Length ? -1 : currentIndex; //match -1 = failure to find conventional in .NET
                ++patternIndex;
            }
            else
            {
                currentIndex = currentIndex + patternIndex - kmpTable[patternIndex];
                patternIndex = kmpTable[patternIndex] > -1 ? kmpTable[patternIndex] : 0;
            }

        return -1;
    }

    private static int[] KMPTable(string sought)
    {
        var table = new int[sought.Length];
        var position = 2;
        var candidate = 0;
        table[0] = -1;
        table[1] = 0;
        while (position < table.Length)
            if (sought[position - 1] == sought[candidate])
                table[position++] = ++candidate;
            else if (candidate > 0)
                candidate = table[candidate];
            else
                table[position++] = 0;
        return table;
    }

    #endregion
}
