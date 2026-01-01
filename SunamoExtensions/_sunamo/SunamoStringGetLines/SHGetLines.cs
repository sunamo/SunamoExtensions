namespace SunamoExtensions._sunamo.SunamoStringGetLines;

/// <summary>
/// String helper for getting lines from text
/// </summary>
internal class SHGetLines
{
    /// <summary>
    /// Splits text into lines by various newline patterns
    /// </summary>
    /// <param name="text">Text to split into lines</param>
    /// <returns>List of lines</returns>
    internal static List<string> GetLines(string text)
    {
        var parts = text.Split(new string[] { "\r\n", "\n\r" }, StringSplitOptions.None).ToList();
        SplitByUnixNewline(parts);
        return parts;
    }

    /// <summary>
    /// Splits lines by Unix newline patterns
    /// </summary>
    /// <param name="lines">Lines to split</param>
    private static void SplitByUnixNewline(List<string> lines)
    {
        SplitBy(lines, "\r");
        SplitBy(lines, "\n");
    }

    /// <summary>
    /// Splits lines by a specific delimiter
    /// </summary>
    /// <param name="lines">Lines to split</param>
    /// <param name="delimiter">Delimiter to split by</param>
    private static void SplitBy(List<string> lines, string delimiter)
    {
        for (int i = lines.Count - 1; i >= 0; i--)
        {
            if (delimiter == "\r")
            {
                var splitByRN = lines[i].Split(new string[] { "\r\n" }, StringSplitOptions.None);
                var splitByNR = lines[i].Split(new string[] { "\n\r" }, StringSplitOptions.None);

                if (splitByRN.Length > 1)
                {
                    ThrowEx.Custom("cannot contain any \r\name, pass already split by this pattern");
                }
                else if (splitByNR.Length > 1)
                {
                    ThrowEx.Custom("cannot contain any \n\r, pass already split by this pattern");
                }
            }

            var splitParts = lines[i].Split(new string[] { delimiter }, StringSplitOptions.None);

            if (splitParts.Length > 1)
            {
                InsertOnIndex(lines, splitParts.ToList(), i);
            }
        }
    }

    /// <summary>
    /// Inserts items at a specific index in the list
    /// </summary>
    /// <param name="lines">Target list</param>
    /// <param name="itemsToInsert">Items to insert</param>
    /// <param name="index">Index to insert at</param>
    private static void InsertOnIndex(List<string> lines, List<string> itemsToInsert, int index)
    {
        itemsToInsert.Reverse();

        lines.RemoveAt(index);

        foreach (var item in itemsToInsert)
        {
            lines.Insert(index, item);
        }
    }
}
