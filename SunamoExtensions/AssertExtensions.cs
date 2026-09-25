namespace SunamoExtensions;

/// <summary>
/// Provides assertion extension methods for comparing collections
/// </summary>
public class AssertExtensions /*: TranslateAble - pryč kvůli přerodu k nuget packages*/
{
    /// <summary>
    /// Error message constant for count mismatch between two collections
    /// </summary>
    public static string XCountInAAndBIsNotEqual = "CountInAAndBIsNotEqual";

    /// <summary>
    /// Compares two lists of tuples for equality
    /// </summary>
    /// <typeparam name="T">Type of the first element in the tuple</typeparam>
    /// <typeparam name="U">Type of the second element in the tuple</typeparam>
    /// <param name="firstList">First list to compare</param>
    /// <param name="secondList">Second list to compare</param>
    /// <exception cref="Exception">Thrown when lists are not equal</exception>
    public static void EqualTuple<T, U>(List<Tuple<T, U>> firstList, List<Tuple<T, U>> secondList)
    {
        if (firstList.Count != secondList.Count) throw new Exception(XCountInAAndBIsNotEqual);

        for (var i = 0; i < firstList.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(firstList[i].Item1, secondList[i].Item1) ||
                !EqualityComparer<U>.Default.Equals(firstList[i].Item2, secondList[i].Item2))
                throw new Exception("a and b is not equal");
    }
}