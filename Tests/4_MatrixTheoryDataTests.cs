using System.Diagnostics.Contracts;
using Xunit.Internal;

namespace Tests;

public class MatrixTheoryDataTests
{
    public static int[] Numbers = { 42, 5, 6 };
    public static string[] Strings = { "Hello", "world!" };
    public static TheoryData<string, int> MyData = new MatrixTheoryData<string, int>(Strings, Numbers);

    // The next test will be launched 6 times (Numbers.Length * Strings.Length)
    [Theory]
    [MemberData(nameof(MyData))]
    public void MyTestMethod(string x, int y)
    {
        Assert.Equal(y, x.Length);
    }
}