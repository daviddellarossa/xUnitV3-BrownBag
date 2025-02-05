namespace Tests;

public class SqlConnection : IDisposable
{
    public SqlConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
    public string ConnectionString { get; private set; }
    public void Dispose()
    {
        // ... clean up the connection ...
    }
}
