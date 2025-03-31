using Xunit.Internal;

namespace Tests;

public class TheoryDataTests
{
    // Synchronous method returning an instance of TheoryData
    public static TheoryData<int, string> TheoryDataForTest => new TheoryData<int, string>()
    {
        { 1, "1" },
        { 2, "2" },
        { 0, "0" },
        new TheoryDataRow<int, string>(-1, "-1")
    };

    // Asynchronous method returning an instance of TheoryData
    public static async Task<TheoryData<int, string>> TheoryDataForTestAsync()
    {
        await Task.Delay(1);
        return new TheoryData<int, string>()
        {
            { 1, "1" },
            { 2, "2" },
            { 0, "0" },
            new TheoryDataRow<int, string>(-1, "-1")
        };
    }

    // This test uses a synchronous method return an instance of TheoryData
    [Theory]
    [MemberData(nameof(TheoryDataForTest))]
    public void Test_Sync(int numericValue, string stringValue)
    {
        Assert.Equal(numericValue.ToString(), stringValue);
    }

    // This test uses an asynchronous method return an instance of TheoryData
    [Theory]
    [MemberData(nameof(TheoryDataForTestAsync))]
    public void Test_Async(int numericValue, string stringValue)
    {
        Assert.Equal(numericValue.ToString(), stringValue);
    }

}


public class TheoryDataRowTests
{
    // It is also possible to return an array of ITheoryDataRows
    public static ITheoryDataRow[] GetMyData()
    {
        return new[] {
            new TheoryDataRow<int, string>(5, "Hello"),
            new TheoryDataRow<int, string>(5, "World"),
            new TheoryDataRow<int, string>(5, "This test will fail, let's skip it").WithSkip("This test is skipped"),
        };
    }

    [Theory]
    [MemberData(nameof(GetMyData))]
    public void MyTestMethod(int x, string y)
    {
        Assert.Equal(x, y.Length);
    }
}