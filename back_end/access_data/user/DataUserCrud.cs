using System.Data;
using BackEnd.Models;
using BackEnd.AccessData;
using back_end.models;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;
public class DataUserCrud
{
    private readonly SqlConnectionFactory _factory;
    private readonly DataErrorHandler _errorHandler;

    public DataUserCrud(SqlConnectionFactory factory, DataErrorHandler errorHandler)
    {
        _factory = factory;
        _errorHandler = errorHandler;
    }

    public async Task<ReturnData> CreateAsync(
        string fullName,
        string email,
        string phoneNumber,
        string passwordHash,
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string storedProc = "usp_users_insert";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@full_name", fullName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            cmd.Parameters.AddWithValue("@password_hash", passwordHash);

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync(cancellationToken))
            {
                bool success = Convert.ToInt32(reader["success"]) == 1;
                string message = reader["message"]?.ToString() ?? "";
                int rows = Convert.ToInt32(reader["rows_affected"]);

                return new ReturnData
                {
                    Success = success,
                    Message = message,
                    RowsAffected = rows
                };
            }

            return new ReturnData
            {
                Success = false,
                Message = "No return from stored procedure",
                RowsAffected = 0
            };
        }
        catch (Exception ex)
        {  
            await _errorHandler.ErrorLogInsertAsync(
                "UserCreate",
                ex.Message,
                cancellationToken
            );

            return new ReturnData
            {
                Success = false,
                Message = "Error while creating user.",
                RowsAffected = 0
            };
        }
    }


    public async Task<ReturnData> UpdateAsync(
        int userId,
        string fullName,
        string email,
        string phoneNumber,
        string passwordHash,
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string storedProc = "usp_users_update";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.Parameters.AddWithValue("@full_name", fullName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone_number", phoneNumber);
            cmd.Parameters.AddWithValue("@password_hash", passwordHash);

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync(cancellationToken))
            {
                bool success = Convert.ToInt32(reader["success"]) == 1;
                string message = reader["message"]?.ToString() ?? "";
                int rows = Convert.ToInt32(reader["rows_affected"]);

                return new ReturnData
                {
                    Success = success,
                    Message = message,
                    RowsAffected = rows
                };
            }

            return new ReturnData
            {
                Success = false,
                Message = "No return from stored procedure",
                RowsAffected = 0
            };
        }
        catch (Exception ex)
        {
            await _errorHandler.ErrorLogInsertAsync(
                "UserUpdate",
                ex.Message,
                cancellationToken
            );

            return new ReturnData
            {
                Success = false,
                Message = "Error while updating user.",
                RowsAffected = 0
            };
        }
    }


    public async Task<ReturnData> DeleteAsync(
        int userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            const string storedProc = "usp_users_delete";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@user_id", userId);

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (await reader.ReadAsync(cancellationToken))
            {
                bool success = Convert.ToInt32(reader["success"]) == 1;
                string message = reader["message"]?.ToString() ?? "";
                int rows = Convert.ToInt32(reader["rows_affected"]);

                return new ReturnData
                {
                    Success = success,
                    Message = message,
                    RowsAffected = rows
                };
            }

            return new ReturnData
            {
                Success = false,
                Message = "No return from stored procedure",
                RowsAffected = 0
            };
        }
        catch (Exception ex)
        {
            await _errorHandler.ErrorLogInsertAsync(
                "UserDelete",
                ex.Message,
                cancellationToken
            );

            return new ReturnData
            {
                Success = false,
                Message = "Error while deleting user.",
                RowsAffected = 0
            };
        }
    }


}