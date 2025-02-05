[assembly: AssemblyFixture(typeof(Tests.DatabaseFixture))]

namespace Tests;


public class AssemblyFixtureClass1
{
    DatabaseFixture fixture;

    public AssemblyFixtureClass1(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ...
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