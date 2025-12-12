using System.Data;
using BackEnd.Models;
using BackEnd.Helper;
using Microsoft.Data.SqlClient;

namespace BackEnd.AccessData;

public class DataFacilityList
{
    private readonly SqlConnectionFactory _factory;

    public DataFacilityList(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IReadOnlyList<FacilityList>> FindAsync(
        string searchText,
        CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_facility_find";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@search_text", searchText);

        var results = new List<FacilityList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<FacilityList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new FacilityList
                {
                    Success = reader.GetInt32(0) == 1,
                    Message = reader.GetString(1)
                });

                return results;
            }
        }

        return results;
    }



    public async Task<IReadOnlyList<FacilityList>> ListAsync(
        long? facilityId = null,
        CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_facility_list";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@facility_id", facilityId ?? (object)DBNull.Value);

        var results = new List<FacilityList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            try
            {
                var model = reader.MapTo<FacilityList>();
                model.Success = true;
                model.Message = "OK";
                results.Add(model);
            }
            catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
            {
                results.Add(new FacilityList
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