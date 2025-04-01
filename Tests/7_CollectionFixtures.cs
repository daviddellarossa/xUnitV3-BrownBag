namespace Tests;

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

[Collection("Database collection")]
public class CollectionFixtureClass1
{
    DatabaseFixture fixture;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fixture">This instance is common to all Test classes belonging to the same collection.</param>
    public CollectionFixtureClass1(DatabaseFixture fixture)
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

[Collection("Database collection")]
public class CollectionFixtureClass2
{
    DatabaseFixture fixture;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fixture">This instance is common to all Test classes belonging to the same collection.</param>
    public CollectionFixtureClass2(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ... tests here ...
}