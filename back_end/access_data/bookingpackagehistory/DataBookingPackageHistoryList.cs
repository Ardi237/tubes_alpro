using System.Data;
using BackEnd.Models;
using BackEnd.Helper;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public class DataBookingPackageHistoryList
{
    private readonly SqlConnectionFactory _factory;

    public DataBookingPackageHistoryList(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IReadOnlyList<BookingPackageHistoryList>> FindAsync(
        string searchText,
        CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_bookingpackagehistory_find";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@search_text", searchText);

        var results = new List<BookingPackageHistoryList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<BookingPackageHistoryList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new BookingPackageHistoryList
                {
                    Success = reader.GetInt32(0) == 1,
                    Message = reader.GetString(1)
                });

                return results;
            }
        }

        return results;
    }



    public async Task<IReadOnlyList<BookingPackageHistoryList>> ListAsync(
        long? historyId = null,
        CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_bookingpackagehistory_list";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@history_id", historyId ?? (object)DBNull.Value);

        var results = new List<BookingPackageHistoryList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<BookingPackageHistoryList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new BookingPackageHistoryList
                {
                    Success = reader.GetInt32(0) == 1,
                    Message = reader.GetString(1)
                });

                return results;
            }
        }

        return results;
    }
}