// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataRoomPackageCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataRoomPackageCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(RoomPackageCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roompackage_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@package_code", model.PackageCode ?? "");
//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@package_name", model.PackageName ?? "");
//         cmd.Parameters.AddWithValue("@benefit_text", model.BenefitText ?? "");
//         cmd.Parameters.AddWithValue("@price", model.Price);
//         cmd.Parameters.AddWithValue("@is_refundable", model.IsRefundable);
//         cmd.Parameters.AddWithValue("@include_breakfast", model.IncludeBreakfast);
//         cmd.Parameters.AddWithValue("@include_gym", model.IncludeGym);
//         cmd.Parameters.AddWithValue("@include_parking", model.IncludeParking);
//         cmd.Parameters.AddWithValue("@other_benefit_json", model.OtherBenefitJson ?? "");
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



//     public async Task<ReturnData> UpdateAsync(int packageId, RoomPackageCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roompackage_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@package_id", packageId);
//         cmd.Parameters.AddWithValue("@package_code", model.PackageCode ?? "");
//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@package_name", model.PackageName ?? "");
//         cmd.Parameters.AddWithValue("@benefit_text", model.BenefitText ?? "");
//         cmd.Parameters.AddWithValue("@price", model.Price);
//         cmd.Parameters.AddWithValue("@is_refundable", model.IsRefundable);
//         cmd.Parameters.AddWithValue("@include_breakfast", model.IncludeBreakfast);
//         cmd.Parameters.AddWithValue("@include_gym", model.IncludeGym);
//         cmd.Parameters.AddWithValue("@include_parking", model.IncludeParking);
//         cmd.Parameters.AddWithValue("@other_benefit_json", model.OtherBenefitJson ?? "");
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



//     public async Task<ReturnData> DeleteAsync(int packageId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_roompackage_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@package_id", packageId);

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
