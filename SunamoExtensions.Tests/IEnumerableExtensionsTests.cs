// variables names: ok
namespace extensions.Tests;

/// <summary>
/// Test data for IEnumerable extension tests
/// </summary>
public static class TestData
{
    /// <summary>
    /// List containing [1, 2, 3]
    /// </summary>
    public static readonly List<int> OneTwoThree = new List<int> { 1, 2, 3 };

    /// <summary>
    /// List containing [3, 2, 1]
    /// </summary>
    public static readonly List<int> ThreeTwoOne = new List<int> { 3, 2, 1 };
}

/// <summary>
/// Tests for IEnumerable extension methods
/// </summary>
public class IEnumerableExtensionsTests
{
    /// <summary>
    /// Tests the SortAsc method
    /// </summary>
    [Fact]
    public void SortAscTest()
    {
        List<int> ascendingList = new List<int>(TestData.OneTwoThree);
        List<int> descendingList = new List<int>(TestData.ThreeTwoOne);

        ascendingList.SortAsc();
        descendingList.SortAsc();

        Assert.Equal(TestData.OneTwoThree, ascendingList);
        Assert.Equal(TestData.OneTwoThree, descendingList);
    }
}
