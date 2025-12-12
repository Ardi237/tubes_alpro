// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataRoomTypeCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataRoomTypeCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(RoomTypeCrud room, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomtype_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@room_type_code", room.RoomTypeCode ?? "");
//         cmd.Parameters.AddWithValue("@hotel_id", room.HotelId);
//         cmd.Parameters.AddWithValue("@name", room.Name ?? "");
//         cmd.Parameters.AddWithValue("@description", room.Description ?? "");
//         cmd.Parameters.AddWithValue("@base_price", room.BasePrice);
//         cmd.Parameters.AddWithValue("@max_guest", room.MaxGuest);
//         cmd.Parameters.AddWithValue("@bed_type", room.BedType ?? "");
//         cmd.Parameters.AddWithValue("@room_size", room.RoomSize ?? "");
//         cmd.Parameters.AddWithValue("@stock_room", room.StockRoom);
//         cmd.Parameters.AddWithValue("@is_active", room.IsActive);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success  = Convert.ToInt32(reader["success"]);
//             int data     = 0;
//             int rowcount = 0;

//             if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                 data = parsed;

//             if (reader["rows_affected"] != DBNull.Value)
//                 rowcount = Convert.ToInt32(reader["rows_affected"]);

//             return new ReturnData(success, data, rowcount);
//         }

//         return new ReturnData(0, 0, 0);
//     }


//     public async Task<ReturnData> UpdateAsync(int roomTypeId, RoomTypeCrud room, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomtype_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@room_type_id", roomTypeId);
//         cmd.Parameters.AddWithValue("@room_type_code", room.RoomTypeCode ?? "");
//         cmd.Parameters.AddWithValue("@hotel_id", room.HotelId);
//         cmd.Parameters.AddWithValue("@name", room.Name ?? "");
//         cmd.Parameters.AddWithValue("@description", room.Description ?? "");
//         cmd.Parameters.AddWithValue("@base_price", room.BasePrice);
//         cmd.Parameters.AddWithValue("@max_guest", room.MaxGuest);
//         cmd.Parameters.AddWithValue("@bed_type", room.BedType ?? "");
//         cmd.Parameters.AddWithValue("@room_size", room.RoomSize ?? "");
//         cmd.Parameters.AddWithValue("@stock_room", room.StockRoom);
//         cmd.Parameters.AddWithValue("@is_active", room.IsActive);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success  = Convert.ToInt32(reader["success"]);
//             int data     = 0;
//             int rowcount = 0;

//             if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                 data = parsed;

//             if (reader["rows_affected"] != DBNull.Value)
//                 rowcount = Convert.ToInt32(reader["rows_affected"]);

//             return new ReturnData(success, data, rowcount);
//         }

//         return new ReturnData(0, 0, 0);
//     }


//     public async Task<ReturnData> DeleteAsync(int roomTypeId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roomtype_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@room_type_id", roomTypeId);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             int success  = Convert.ToInt32(reader["success"]);
//             int data     = 0;
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
