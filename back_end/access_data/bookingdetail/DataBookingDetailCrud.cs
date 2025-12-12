// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataBookingDetailCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataBookingDetailCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }


//     public async Task<ReturnData> CreateAsync(BookingDetailCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingdetail_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@package_id", model.PackageId);
//         cmd.Parameters.AddWithValue("@qty_room", model.QtyRoom);
//         cmd.Parameters.AddWithValue("@price_per_night", model.PricePerNight);
//         cmd.Parameters.AddWithValue("@nights", model.Nights);
//         cmd.Parameters.AddWithValue("@subtotal", model.Subtotal);
//         cmd.Parameters.AddWithValue("@price_room_base", model.PriceRoomBase);
//         cmd.Parameters.AddWithValue("@price_package_addon", model.PricePackageAddon);
//         cmd.Parameters.AddWithValue("@roomtype_snapshot_json", model.RoomtypeSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@package_snapshot_json", model.PackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@tax_amount", model.TaxAmount);
//         cmd.Parameters.AddWithValue("@service_fee_amount", model.ServiceFeeAmount);
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




//     public async Task<ReturnData> UpdateAsync(
//         int bookingDetailId,
//         BookingDetailCrud model,
//         CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingdetail_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_detail_id", bookingDetailId);
//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@room_type_id", model.RoomTypeId);
//         cmd.Parameters.AddWithValue("@package_id", model.PackageId);
//         cmd.Parameters.AddWithValue("@qty_room", model.QtyRoom);
//         cmd.Parameters.AddWithValue("@price_per_night", model.PricePerNight);
//         cmd.Parameters.AddWithValue("@nights", model.Nights);
//         cmd.Parameters.AddWithValue("@subtotal", model.Subtotal);
//         cmd.Parameters.AddWithValue("@price_room_base", model.PriceRoomBase);
//         cmd.Parameters.AddWithValue("@price_package_addon", model.PricePackageAddon);
//         cmd.Parameters.AddWithValue("@roomtype_snapshot_json", model.RoomtypeSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@package_snapshot_json", model.PackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@tax_amount", model.TaxAmount);
//         cmd.Parameters.AddWithValue("@service_fee_amount", model.ServiceFeeAmount);
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




//     public async Task<ReturnData> DeleteAsync(int bookingDetailId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingdetail_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_detail_id", bookingDetailId);

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
