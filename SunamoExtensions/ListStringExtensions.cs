namespace SunamoExtensions;

/// <summary>
/// Represents the list string extensions type.
/// </summary>
public static class ListStringExtensions
{
    /// <summary>
    /// Insert multiline string.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="index">The index.</param>
    /// <param name="toInsert">The to insert.</param>
    public static void InsertMultilineString(this List<string> list, int index, string toInsert)
    {
        var lines = SHGetLines.GetLines(toInsert);

        for (var i = lines.Count - 1; i >= 0; i--) list.Insert(index, lines[i]);
    }
}
