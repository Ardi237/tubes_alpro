using BackEnd.AccessData;
using Microsoft.Data.SqlClient;

namespace BackEnd.Helper;

public static class ConnectionTester
{
    public static async Task CheckAsync(SqlConnectionFactory factory, CancellationToken cancellationToken = default)
    {
        try
        {
            await factory.TestConnectionAsync(cancellationToken);
        }
        catch (SqlException ex)
        {
            throw new SqlConnectionException("SQL Server refused the connection.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new SqlConnectionException("Connection could not be established.", ex);
        }
    }
}

public sealed class SqlConnectionException : Exception
{
    public SqlConnectionException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
