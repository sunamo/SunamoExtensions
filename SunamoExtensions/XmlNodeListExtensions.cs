namespace SunamoExtensions;

/// <summary>
/// Represents the xml node list extensions type.
/// </summary>
public static class XmlNodeListExtensions
{
    #region For easy copy from XmlNodeListExtensions.cs

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="nodeList">The node list.</param>
    /// <param name="node">The node.</param>
    /// <returns>The contains result.</returns>
    public static bool Contains(this XmlNodeList nodeList, XmlNode node)
    {
        foreach (var item in nodeList)
            if (item == node)
                return true;
        return false;
    }

    /// <summary>
    /// First.
    /// </summary>
    /// <param name="nodeList">The node list.</param>
    /// <param name="name">The name.</param>
    /// <returns>The first result.</returns>
    public static XmlNode? First(this XmlNodeList nodeList, string name)
    {
        foreach (XmlNode item in nodeList)
            if (item.Name == name)
                return item;
        return null;
    }

    /// <summary>
    /// With name.
    /// </summary>
    /// <param name="nodeList">The node list.</param>
    /// <param name="name">The name.</param>
    /// <returns>The with name result.</returns>
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
