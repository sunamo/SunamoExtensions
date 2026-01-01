namespace SunamoExtensions._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.

/// <summary>
/// Exception handling utilities
/// </summary>
internal sealed partial class Exceptions
{
    #region Other

    /// <summary>
    /// Converts exception and optionally its inner exceptions to a text representation
    /// </summary>
    /// <param name="exception">Exception to convert</param>
    /// <param name="isIncludingInner">Whether to include inner exceptions</param>
    /// <returns>String representation of the exception(s)</returns>
    internal static string TextOfExceptions(Exception exception, bool isIncludingInner = true)
    {
        if (exception == null) return string.Empty;
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Exception:");
        stringBuilder.AppendLine(exception.Message);
        if (isIncludingInner)
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                stringBuilder.AppendLine(exception.Message);
            }
        var result = stringBuilder.ToString();
        return result;
    }

    #endregion

    #region IsNullOrWhitespace
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
    #endregion

    #region OnlyReturnString



    #endregion



}
