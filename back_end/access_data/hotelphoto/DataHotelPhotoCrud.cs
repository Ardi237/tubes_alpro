// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataHotelPhotoCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataHotelPhotoCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(HotelPhotoCrud photo, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotelphoto_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@hotel_id", photo.HotelId);
//         cmd.Parameters.AddWithValue("@image_url", photo.ImageUrl ?? "");
//         cmd.Parameters.AddWithValue("@is_cover", photo.IsCover);
//         cmd.Parameters.AddWithValue("@sort_order", photo.SortOrder);
//         cmd.Parameters.AddWithValue("@is_active", photo.IsActive);

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


//     public async Task<ReturnData> UpdateAsync(int photoId, HotelPhotoCrud photo, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotelphoto_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@photo_id", photoId);
//         cmd.Parameters.AddWithValue("@hotel_id", photo.HotelId);
//         cmd.Parameters.AddWithValue("@image_url", photo.ImageUrl ?? "");
//         cmd.Parameters.AddWithValue("@is_cover", photo.IsCover);
//         cmd.Parameters.AddWithValue("@sort_order", photo.SortOrder);
//         cmd.Parameters.AddWithValue("@is_active", photo.IsActive);

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


//     public async Task<ReturnData> DeleteAsync(int photoId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_hotelphoto_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@photo_id", photoId);

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
