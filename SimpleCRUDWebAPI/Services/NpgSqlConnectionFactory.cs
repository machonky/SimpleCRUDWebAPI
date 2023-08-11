using Npgsql;
using System.Data;

namespace SimpleCRUDWebAPI.Services;

public class NpgSqlConnectionFactory : IDbConnectionFactory
{
    private readonly string? _connectionString;

    public NpgSqlConnectionFactory(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
