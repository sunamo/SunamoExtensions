namespace SunamoExtensions._sunamo;

/// <summary>
/// Helper class for throwing exceptions with debugger break
/// </summary>
internal class ThrowEx
{
    /// <summary>
    /// Throws a custom exception after triggering debugger break
    /// </summary>
    /// <param name="message">Exception message</param>
    internal static void Custom(string message)
    {
        Debugger.Break();
        throw new Exception(message);
    }
}
