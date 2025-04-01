[assembly: AssemblyFixture(typeof(Tests.DatabaseFixture))]

namespace Tests;


public class AssemblyFixtureClass1
{
    DatabaseFixture fixture;

    public AssemblyFixtureClass1(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ... tests here ...
    [Fact]
    public void Test1()
    {
        Assert.NotNull(fixture);
    }
}

public class AssemblyFixtureClass2
{
    DatabaseFixture fixture;

    public AssemblyFixtureClass2(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ...
}