namespace SunamoExtensions;

public class AssertExtensions /*: TranslateAble - pryč kvůli přerodu k nuget packages*/
{
    public static string XCountInAAndBIsNotEqual = "CountInAAndBIsNotEqual";

    public static void EqualTuple<T, U>(List<Tuple<T, U>> firstList, List<Tuple<T, U>> secondList)
    {
        if (firstList.Count != secondList.Count) throw new Exception(XCountInAAndBIsNotEqual);

        for (var i = 0; i < firstList.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(firstList[i].Item1, secondList[i].Item1) ||
                !EqualityComparer<U>.Default.Equals(firstList[i].Item2, secondList[i].Item2))
                throw new Exception("a and b is not equal");
    }
}
