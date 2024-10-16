namespace SunamoExtensions;

public static class StringExtensions
{

    public static IList<string> SplitAndKeep(this string s, List<string> delims)
    {
        //    // delims allow only char[], not List<string>
        //    //int start = 0, index;
        //    //string selectedSeperator = null;
        //    //while ((index = s.IndexOfAny(delims, start, out selectedSeperator)) != -1)
        //    //{
        //    //    if (selectedSeperator == null)
        //    //        continue;
        //    //    if (index - start > 0)
        //    //        yield return s.Substring(start, index - start);
        //    //    yield return s.Substring(index, selectedSeperator.Length);
        //    //    start = index + selectedSeperator.Length;
        //    //}
        //    //if (start < s.Length)
        //    //{
        //    //    yield return s.Substring(start);
        //    //}
        return null;
    }
}