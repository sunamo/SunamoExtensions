namespace SunamoExtensions;

/// <summary>
/// Extension methods for StringBuilder type
/// </summary>
public static class StringBuilderExtensions
{
    #region For easy copy

    /// <summary>
    /// Removes trailing whitespace from the end of the StringBuilder
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to trim</param>
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
    /// Appends a formatted string followed by a line terminator
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to append to</param>
    /// <param name="format">Format string</param>
    /// <param name="args">Format arguments</param>
    public static void AppendFormatLine(this StringBuilder stringBuilder, string format, params string[] args)
    {
        stringBuilder.AppendFormat(format, args);
        stringBuilder.AppendLine();
    }

    /// <summary>
    /// Determines whether the end of the StringBuilder matches the specified string
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to check</param>
    /// <param name="value">String to compare</param>
    /// <returns>True if StringBuilder ends with the specified value</returns>
    public static bool EndsWith(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder.Length < value.Length)
            return false;

        var end = stringBuilder.ToString(stringBuilder.Length - value.Length, value.Length);
        return end.Equals(value);
    }

    /// <summary>
    /// Determines whether the beginning of the StringBuilder matches the specified string
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to check</param>
    /// <param name="value">String to compare</param>
    /// <returns>True if StringBuilder starts with the specified value</returns>
    public static bool StartWith(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder.Length < value.Length)
            return false;

        var start = stringBuilder.ToString(0, value.Length);
        return start.Equals(value);
    }

    /// <summary>
    /// Removes all occurrences of the specified suffix from the end of the StringBuilder
    /// </summary>
    /// <param name="input">StringBuilder to process</param>
    /// <param name="suffix">Suffix to remove</param>
    /// <returns>StringBuilder with suffix removed</returns>
    public static StringBuilder TrimEnd(this StringBuilder input, string suffix)
    {
        while (input.EndsWith(suffix)) return input.Substring(0, input.Length - suffix.Length);
        return input;
    }

    /// <summary>
    /// Removes all occurrences of the specified prefix from the start of the StringBuilder
    /// </summary>
    /// <param name="input">StringBuilder to process</param>
    /// <param name="prefix">Prefix to remove</param>
    /// <returns>StringBuilder with prefix removed</returns>
    public static StringBuilder TrimStart(this StringBuilder input, string prefix)
    {
        while (input.StartWith(prefix)) return input.Substring(prefix.Length, input.Length - prefix.Length);
        return input;
    }

    /// <summary>
    /// Retrieves a substring from this StringBuilder starting at the specified position
    /// </summary>
    /// <param name="input">StringBuilder to extract from</param>
    /// <param name="indexFrom">Starting position (default: 1)</param>
    /// <returns>Substring as StringBuilder</returns>
    public static StringBuilder Substring(this StringBuilder input, int indexFrom = 1)
    {
        return input.Substring(indexFrom, input.Length - 1);
    }

    /// <summary>
    /// Retrieves a substring from this StringBuilder with specified start position and length
    /// </summary>
    /// <param name="input">StringBuilder to extract from</param>
    /// <param name="index">Starting position</param>
    /// <param name="length">Number of characters to extract</param>
    /// <returns>Substring as StringBuilder</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index or length is out of range</exception>
    public static StringBuilder Substring(this StringBuilder input, int index, int length)
    {
        var subString = new StringBuilder();
        if (index + length - 1 >= input.Length || index < 0)
            throw new ArgumentOutOfRangeException("Index out of range!");
        var endIndex = index + length;
        for (var i = index; i < endIndex; i++) subString.Append(input[i]);
        return subString;
    }

    /// <summary>
    /// Removes leading whitespace from the start of the StringBuilder
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to trim</param>
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
    /// Removes leading and trailing whitespace from the StringBuilder
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to trim</param>
    public static void Trim(this StringBuilder stringBuilder)
    {
        TrimEnd(stringBuilder);
        TrimStart(stringBuilder);
    }

    #region For easy copy from StringBuilderExtensions.cs

    /// <summary>
    /// Determines whether the StringBuilder contains the specified string
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to search in</param>
    /// <param name="value">String to search for</param>
    /// <returns>True if the string is found</returns>
    public static bool Contains(this StringBuilder stringBuilder, string value)
    {
        return stringBuilder.IndexOf(value) != -1;
    }

    /// <summary>
    /// Returns the index of the first occurrence of the specified string in the StringBuilder
    /// </summary>
    /// <param name="stringBuilder">StringBuilder to search in</param>
    /// <param name="value">String to search for</param>
    /// <returns>Index of the first occurrence, or -1 if not found</returns>
    /// <exception cref="ArgumentNullException">Thrown when stringBuilder or value is null</exception>
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

    /// <summary>
    /// Creates a Knuth-Morris-Pratt (KMP) table for pattern matching
    /// </summary>
    /// <param name="sought">Pattern string to create table for</param>
    /// <returns>KMP table array</returns>
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
