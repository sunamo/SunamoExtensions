// variables names: ok
namespace SunamoExtensions.Tests;

/// <summary>
/// Tests for ListStringExtensions
/// </summary>
public class ListStringExtensionsTests
{
    /// <summary>
    /// Tests the InsertMultilineString method
    /// </summary>
    [Fact]
    public void InsertMultilineStringTest()
    {
        List<string> lines = SHGetLines.GetLines(@"a
b
c");

        lines.InsertMultilineString(1, @"1
2");

        // Verify that the multiline string was inserted at index 1
        Assert.Equal(5, lines.Count);
        Assert.Equal("a", lines[0]);
        Assert.Equal("1", lines[1]);
        Assert.Equal("2", lines[2]);
        Assert.Equal("b", lines[3]);
        Assert.Equal("c", lines[4]);
    }
}
