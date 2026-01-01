namespace SunamoExtensions;

/// <summary>
/// Extension methods for XmlNodeList type
/// </summary>
public static class XmlNodeListExtensions
{
    #region For easy copy from XmlNodeListExtensions.cs

    /// <summary>
    /// Determines whether the node list contains the specified node
    /// </summary>
    /// <param name="nodeList">Node list to search in</param>
    /// <param name="node">Node to search for</param>
    /// <returns>True if the node is found</returns>
    public static bool Contains(this XmlNodeList nodeList, XmlNode node)
    {
        foreach (var item in nodeList)
            if (item == node)
                return true;
        return false;
    }

    /// <summary>
    /// Returns the first node with the specified name
    /// </summary>
    /// <param name="nodeList">Node list to search in</param>
    /// <param name="name">Name of the node to find</param>
    /// <returns>First matching node, or null if not found</returns>
    public static XmlNode? First(this XmlNodeList nodeList, string name)
    {
        foreach (XmlNode item in nodeList)
            if (item.Name == name)
                return item;
        return null;
    }

    /// <summary>
    /// Returns all nodes with the specified name
    /// </summary>
    /// <param name="nodeList">Node list to search in</param>
    /// <param name="name">Name of the nodes to find</param>
    /// <returns>List of matching nodes</returns>
    public static List<XmlNode> WithName(this XmlNodeList nodeList, string name)
    {
        var result = new List<XmlNode>();
        foreach (XmlNode item in nodeList)
            if (item.Name == name)
                result.Add(item);
        return result;
    }

    #endregion
}
