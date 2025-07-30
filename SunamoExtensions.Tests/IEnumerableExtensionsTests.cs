namespace extensions.Tests;

public static class TestData
{
    public static readonly List<int> _123 = new List<int> { 1, 2, 3 };
    public static readonly List<int> _321 = new List<int> { 3, 2, 1 };
}

public class IEnumerableExtensionsTests
{
    [Fact]
    public void SortAscTest()
    {
        List<int> l1 = new List<int>(TestData._123);
        List<int> l2 = new List<int>(TestData._321);

        l1.SortAsc();
        l2.SortAsc();

        Assert.Equal(TestData._123, l1);
        Assert.Equal(TestData._123, l2);
    }
}
