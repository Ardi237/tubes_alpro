using System.Data;
using BackEnd.Models;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public sealed class SqlConnectionFactory
{
    private readonly DatabaseConfig _config;

    public SqlConnectionFactory(DatabaseConfig config)
    {
        _config = config;
    }

    public SqlConnection Create()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = $"{_config.Host},{_config.Port}",
            InitialCatalog = _config.Name,
            IntegratedSecurity = true,
            Encrypt = _config.Encrypt,
            TrustServerCertificate = _config.TrustServerCertificate,
        };

        return new SqlConnection(builder.ConnectionString);
    }

    public async Task TestConnectionAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = Create();
        await connection.OpenAsync(cancellationToken);
        if (connection.State != ConnectionState.Open)
        {
            throw new InvalidOperationException("Connection did not reach the Open state.");
        }
    }
}
