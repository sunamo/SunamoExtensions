namespace SunamoExtensions;

public static class XmlNodeListExtensions
{
    #region For easy copy from XmlNodeListExtensions.cs

    public static bool Contains(this XmlNodeList nodeList, XmlNode node)
    {
        foreach (var item in nodeList)
            if (item == node)
                return true;
        return false;
    }

    public static XmlNode? First(this XmlNodeList nodeList, string name)
    {
        foreach (XmlNode item in nodeList)
            if (item.Name == name)
                return item;
        return null;
    }

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
