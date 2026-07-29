using System.Data;
using FinOpsCore.Application.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace FinOpsCore.Infrastructure.Data.Connections;

public class OracleConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public OracleConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        var connection = new OracleConnection(_connectionString);
        connection.Open();
        return connection;
    }
}