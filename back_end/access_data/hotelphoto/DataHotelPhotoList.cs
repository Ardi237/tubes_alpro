using System.Data;
using BackEnd.Models;
using BackEnd.Helper;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public class DataHotelPhotoList
{
    private readonly SqlConnectionFactory _factory;

    public DataHotelPhotoList(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IReadOnlyList<HotelPhotoList>> FindAsync(string searchText, CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_hotelphoto_find";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@search_text", searchText);

        var results = new List<HotelPhotoList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<HotelPhotoList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new HotelPhotoList
                {
                    Success = reader.GetInt32(0) == 1,
                    Message = reader.GetString(1)
                });

                return results;
            }
        }

        return results;
    }


    public async Task<IReadOnlyList<HotelPhotoList>> ListAsync(long? photoId = null, CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_hotelphoto_list";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@photo_id", photoId ?? (object)DBNull.Value);

        var results = new List<HotelPhotoList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<HotelPhotoList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new HotelPhotoList
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