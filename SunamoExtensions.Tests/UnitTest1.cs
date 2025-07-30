namespace SunamoExtensions.Tests;

public class ListStringExtensionsTests
{
    [Fact]
    public void InsertMultilineStringTest()
    {
        List<string> a = SHGetLines.GetLines(@"a
b
c");

        a.InsertMultilineString(1, @"1
2");
    }
}
