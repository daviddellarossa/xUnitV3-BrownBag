using ClassLibrary;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void AddTest()
    {
        Assert.Equal(5, Class1.Add(2, 3));
    }
}
