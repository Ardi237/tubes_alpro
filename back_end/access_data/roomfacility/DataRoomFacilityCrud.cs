// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataRoomFacilityCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataRoomFacilityCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(RoomFacilityCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomfacility_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@facility_id", model.FacilityId);
//         cmd.Parameters.AddWithValue("@is_active", model.IsActive);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success = Convert.ToInt32(reader["success"]);
//             int data = 0;
//             int rowcount = 0;

//             if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                 data = parsed;

//             if (reader["rows_affected"] != DBNull.Value)
//                 rowcount = Convert.ToInt32(reader["rows_affected"]);

//             return new ReturnData(success, data, rowcount);
//         }

//         return new ReturnData(0, 0, 0);
//     }


//     public async Task<ReturnData> UpdateAsync(int roomFacilityId, RoomFacilityCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomfacility_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@roomfacility_id", roomFacilityId);
//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@facility_id", model.FacilityId);
//         cmd.Parameters.AddWithValue("@is_active", model.IsActive);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success = Convert.ToInt32(reader["success"]);
//             int data = 0;
//             int rowcount = 0;

//             if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                 data = parsed;

//             if (reader["rows_affected"] != DBNull.Value)
//                 rowcount = Convert.ToInt32(reader["rows_affected"]);

//             return new ReturnData(success, data, rowcount);
//         }

//         return new ReturnData(0, 0, 0);
//     }


//     public async Task<ReturnData> DeleteAsync(int roomFacilityId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomfacility_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@roomfacility_id", roomFacilityId);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success = Convert.ToInt32(reader["success"]);
//             int data = 0;
//             int rowcount = 0;

//             if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                 data = parsed;

//             if (reader["rows_affected"] != DBNull.Value)
//                 rowcount = Convert.ToInt32(reader["rows_affected"]);

//             return new ReturnData(success, data, rowcount);
//         }

//         return new ReturnData(0, 0, 0);
//     }
// }
