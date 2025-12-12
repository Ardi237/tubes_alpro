// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataHotelCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataHotelCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(HotelCrud hotel, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotel_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@hotel_code", hotel.HotelCode ?? "");
//         cmd.Parameters.AddWithValue("@name", hotel.Name ?? "");
//         cmd.Parameters.AddWithValue("@address", hotel.Address ?? "");
//         cmd.Parameters.AddWithValue("@city", hotel.City ?? "");
//         cmd.Parameters.AddWithValue("@description", hotel.Description ?? "");
//         cmd.Parameters.AddWithValue("@rating_avg", hotel.RatingAvg);
//         cmd.Parameters.AddWithValue("@checkin_time", hotel.CheckinTime ?? "");
//         cmd.Parameters.AddWithValue("@checkout_time", hotel.CheckoutTime ?? "");
//         cmd.Parameters.AddWithValue("@is_active", hotel.IsActive);

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


//     public async Task<ReturnData> UpdateAsync(int hotelId, HotelCrud hotel, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotel_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@hotel_id", hotelId);
//         cmd.Parameters.AddWithValue("@hotel_code", hotel.HotelCode ?? "");
//         cmd.Parameters.AddWithValue("@name", hotel.Name ?? "");
//         cmd.Parameters.AddWithValue("@address", hotel.Address ?? "");
//         cmd.Parameters.AddWithValue("@city", hotel.City ?? "");
//         cmd.Parameters.AddWithValue("@description", hotel.Description ?? "");
//         cmd.Parameters.AddWithValue("@rating_avg", hotel.RatingAvg);
//         cmd.Parameters.AddWithValue("@checkin_time", hotel.CheckinTime ?? "");
//         cmd.Parameters.AddWithValue("@checkout_time", hotel.CheckoutTime ?? "");
//         cmd.Parameters.AddWithValue("@is_active", hotel.IsActive);

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


//     public async Task<ReturnData> DeleteAsync(int hotelId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotel_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@hotel_id", hotelId);

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
