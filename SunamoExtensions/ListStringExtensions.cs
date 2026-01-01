namespace SunamoExtensions;

/// <summary>
/// Extension methods for List of string type
/// </summary>
public static class ListStringExtensions
{
    /// <summary>
    /// Inserts a multiline string into the list, splitting it into individual lines
    /// </summary>
    /// <param name="list">List to insert lines into</param>
    /// <param name="index">Index to insert at</param>
    /// <param name="toInsert">Multiline string to insert</param>
    public static void InsertMultilineString(this List<string> list, int index, string toInsert)
    {
        var lines = SHGetLines.GetLines(toInsert);

        for (var i = lines.Count - 1; i >= 0; i--) list.Insert(index, lines[i]);
    }
}
