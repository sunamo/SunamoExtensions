namespace SunamoExtensions._sunamo;
/// <summary>
/// Jednoduše proto že nemůžu dědit z SunExc
/// společně se SunamoValues by mi vznikl potom cycle detected
/// SunExc bude tedy zvláštní případ první ligy kdy bude obsahovat jen deps 1. ligy ale zároveň jej nikdo z 1. ligy nebude moct použít
/// </summary>
internal class ThrowEx
{
}
