// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataBookingPackageHistoryCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataBookingPackageHistoryCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }


//     public async Task<ReturnData> CreateAsync(BookingPackageHistoryCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpackagehistory_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@old_package_id", model.OldPackageId);
//         cmd.Parameters.AddWithValue("@new_package_id", model.NewPackageId);
//         cmd.Parameters.AddWithValue("@difference_amount", model.DifferenceAmount);
//         cmd.Parameters.AddWithValue("@action_type", model.ActionType ?? "");
//         cmd.Parameters.AddWithValue("@created_at", model.CreatedAt);
//         cmd.Parameters.AddWithValue("@action_by_admin_id", model.ActionByAdminId);
//         cmd.Parameters.AddWithValue("@action_by_user_id", model.ActionByUserId);
//         cmd.Parameters.AddWithValue("@remarks", model.Remarks ?? "");
//         cmd.Parameters.AddWithValue("@old_package_snapshot_json", model.OldPackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@new_package_snapshot_json", model.NewPackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@old_total_amount", model.OldTotalAmount);
//         cmd.Parameters.AddWithValue("@new_total_amount", model.NewTotalAmount);
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



//     public async Task<ReturnData> UpdateAsync(int historyId, BookingPackageHistoryCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpackagehistory_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@history_id", historyId);
//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@old_package_id", model.OldPackageId);
//         cmd.Parameters.AddWithValue("@new_package_id", model.NewPackageId);
//         cmd.Parameters.AddWithValue("@difference_amount", model.DifferenceAmount);
//         cmd.Parameters.AddWithValue("@action_type", model.ActionType ?? "");
//         cmd.Parameters.AddWithValue("@created_at", model.CreatedAt);
//         cmd.Parameters.AddWithValue("@action_by_admin_id", model.ActionByAdminId);
//         cmd.Parameters.AddWithValue("@action_by_user_id", model.ActionByUserId);
//         cmd.Parameters.AddWithValue("@remarks", model.Remarks ?? "");
//         cmd.Parameters.AddWithValue("@old_package_snapshot_json", model.OldPackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@new_package_snapshot_json", model.NewPackageSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@old_total_amount", model.OldTotalAmount);
//         cmd.Parameters.AddWithValue("@new_total_amount", model.NewTotalAmount);
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



//     public async Task<ReturnData> DeleteAsync(int historyId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpackagehistory_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@history_id", historyId);

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
