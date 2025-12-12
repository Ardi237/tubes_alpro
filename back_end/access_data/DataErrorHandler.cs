using System.Data;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public class DataErrorHandler
{
    private readonly SqlConnectionFactory _factory;

    public DataErrorHandler(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task ErrorLogInsertAsync(
        string error_section,
        string error_message,
        CancellationToken cancellationToken = default)
    {
        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand("usp_error_log_create", conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@error_section", error_section);
        cmd.Parameters.AddWithValue("@error_message", error_message);

        await cmd.ExecuteNonQueryAsync(cancellationToken);
    }
}
