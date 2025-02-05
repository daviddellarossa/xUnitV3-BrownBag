namespace Tests;

public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Db = new SqlConnection("MyConnectionString");

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
        Db.Dispose();
    }

    public SqlConnection Db { get; private set; }
}

public class ClassFixtureTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture fixture;

    public ClassFixtureTests(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ... write tests, using fixture.Db to get access to the SQL Server ...
}
