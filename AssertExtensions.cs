using SunamoI18N.Values;

namespace SunamoExtensions;

public class AssertExtensions : TranslateAble
{


    static Type type = typeof(AssertExtensions);
    public static void EqualTuple<T, U>(List<Tuple<T, U>> a, List<Tuple<T, U>> b)
    {
        if (a.Count != b.Count)
        {
            ThrowEx.Custom(i18n(XlfKeys.CountInAAndBIsNotEqual));
        }

        for (int i = 0; i < a.Count; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(a[i].Item1, b[i].Item1) || !EqualityComparer<U>.Default.Equals(a[i].Item2, b[i].Item2))
            {
                ThrowEx.Custom("a and b is not equal");
            }
        }


    }
}
