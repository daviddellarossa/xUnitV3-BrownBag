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

    public CollectionFixtureClass1(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }
}

[Collection("Database collection")]
public class CollectionFixtureClass2
{
    // ...
}