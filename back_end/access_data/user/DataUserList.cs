using System.Data;
using BackEnd.Models;
using BackEnd.Helper;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public class DataUserList
{
    private readonly SqlConnectionFactory _factory;
    private readonly DataErrorHandler _errorHandler;


    public DataUserList(SqlConnectionFactory factory, DataErrorHandler errorHandler)
    {
        _factory = factory;
        _errorHandler = errorHandler;

    }

    public async Task<UserList[]> FindAsync(
        string searchText,
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string storedProc = "usp_users_find";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@search_text", searchText ?? "");

            var results = new List<UserList>();

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                try
                {
                    var model = reader.MapTo<UserList>();

                    model.Success = true;
                    model.Message = "OK";

                    results.Add(model);
                }
                catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
                {
                    results.Add(new UserList
                    {
                        Success = Convert.ToInt32(reader["success"]) == 1,
                        Message = reader["message"]?.ToString()
                    });

                    return results.ToArray();
                }
            }

            return results.ToArray();
        }
        catch (Exception ex)
        {
            await _errorHandler.ErrorLogInsertAsync(
                "UserFind",
                ex.Message,
                cancellationToken
            );

            return
            [
                new UserList
                {
                    Success = false,
                    Message = "Error while searching user."
                }
            ];
        }
    }

    public async Task<UserList[]> ListAsync(
        long? userId = null, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string storedProc = "usp_users_list";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@user_id", userId ?? (object)DBNull.Value);

            var results = new List<UserList>();

            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                try
                {
                    var model = reader.MapTo<UserList>();

                    model.Success = true;
                    model.Message = "OK";

                    results.Add(model);
                }
                catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
                {
                    // SP return error row
                    results.Add(new UserList
                    {
                        Success = Convert.ToInt32(reader["success"]) == 1,
                        Message = reader["message"]?.ToString()
                    });

                    return results.ToArray();
                }
            }

            return results.ToArray();
        }
        catch (Exception ex)
        {
            await _errorHandler.ErrorLogInsertAsync(
                "UserList",
                ex.Message,
                cancellationToken
            );

            return Array.Empty<UserList>();
        }
    }
}