using Npgsql;
using System.Data;

namespace Tspu.Service;

public class DataContext
{
    public IDbConnection CreateConnection()
    {
        var connectionString = $"Host=localhost; Database=postgres; Username=postgres; Password=7;";
        return new NpgsqlConnection(connectionString);
    }
}
