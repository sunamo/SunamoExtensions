namespace SunamoExtensions;

/// <summary>
/// Represents the assert extensions type.
/// </summary>
public class AssertExtensions /* : TranslateAble - removed because of the transition to nuget packages*/
{
    /// <summary>
    /// The x count in a and b is not equal.
    /// </summary>
    public static string XCountInAAndBIsNotEqual = "CountInAAndBIsNotEqual";

    /// <summary>
    /// Equal tuple t u.
    /// </summary>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>The equal tuple t u result.</returns>
    public static void EqualTuple<T, U>(List<Tuple<T, U>> firstList, List<Tuple<T, U>> secondList)
    {
        if (firstList.Count != secondList.Count) throw new Exception(XCountInAAndBIsNotEqual);

        for (var i = 0; i < firstList.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(firstList[i].Item1, secondList[i].Item1) ||
                !EqualityComparer<U>.Default.Equals(firstList[i].Item2, secondList[i].Item2))
                throw new Exception("a and b is not equal");
    }
}
