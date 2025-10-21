// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoExtensions._sunamo;

internal class ThrowEx
{
    internal static void Custom(string v)
    {
        Debugger.Break();
        throw new Exception(v);
    }
}