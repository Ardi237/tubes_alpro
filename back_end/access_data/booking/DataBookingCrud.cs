//     using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataBookingCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataBookingCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }


//     public async Task<ReturnData> CreateAsync(BookingCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_booking_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_code", model.BookingCode ?? "");
//         cmd.Parameters.AddWithValue("@user_id", model.UserId);
//         cmd.Parameters.AddWithValue("@hotel_id", model.HotelId);
//         cmd.Parameters.AddWithValue("@checkin_date", model.CheckinDate);
//         cmd.Parameters.AddWithValue("@checkout_date", model.CheckoutDate);
//         cmd.Parameters.AddWithValue("@booking_status", model.BookingStatus ?? "");
//         cmd.Parameters.AddWithValue("@special_request", model.SpecialRequest ?? "");
//         cmd.Parameters.AddWithValue("@insurance_id", model.InsuranceId);
//         cmd.Parameters.AddWithValue("@insurance_premium_amount", model.InsurancePremiumAmount);
//         cmd.Parameters.AddWithValue("@payment_deadline", model.PaymentDeadline);
//         cmd.Parameters.AddWithValue("@can_refund", model.CanRefund);
//         cmd.Parameters.AddWithValue("@total_nights", model.TotalNights);
//         cmd.Parameters.AddWithValue("@total_amount", model.TotalAmount);
//         cmd.Parameters.AddWithValue("@check_in_time", model.CheckInTime ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@check_out_time", model.CheckOutTime ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@booking_source", model.BookingSource ?? "");
//         cmd.Parameters.AddWithValue("@guest_count", model.GuestCount);
//         cmd.Parameters.AddWithValue("@hotel_snapshot_json", model.HotelSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@room_snapshot_json", model.RoomSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@insurance_snapshot_json", model.InsuranceSnapshotJson ?? "");
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
//         int bookingId,
//         BookingCrud model,
//         CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_booking_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_id", bookingId);
//         cmd.Parameters.AddWithValue("@booking_code", model.BookingCode ?? "");
//         cmd.Parameters.AddWithValue("@user_id", model.UserId);
//         cmd.Parameters.AddWithValue("@hotel_id", model.HotelId);
//         cmd.Parameters.AddWithValue("@checkin_date", model.CheckinDate);
//         cmd.Parameters.AddWithValue("@checkout_date", model.CheckoutDate);
//         cmd.Parameters.AddWithValue("@booking_status", model.BookingStatus ?? "");
//         cmd.Parameters.AddWithValue("@special_request", model.SpecialRequest ?? "");
//         cmd.Parameters.AddWithValue("@insurance_id", model.InsuranceId);
//         cmd.Parameters.AddWithValue("@insurance_premium_amount", model.InsurancePremiumAmount);
//         cmd.Parameters.AddWithValue("@payment_deadline", model.PaymentDeadline);
//         cmd.Parameters.AddWithValue("@can_refund", model.CanRefund);
//         cmd.Parameters.AddWithValue("@total_nights", model.TotalNights);
//         cmd.Parameters.AddWithValue("@total_amount", model.TotalAmount);
//         cmd.Parameters.AddWithValue("@check_in_time", model.CheckInTime ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@check_out_time", model.CheckOutTime ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@booking_source", model.BookingSource ?? "");
//         cmd.Parameters.AddWithValue("@guest_count", model.GuestCount);
//         cmd.Parameters.AddWithValue("@hotel_snapshot_json", model.HotelSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@room_snapshot_json", model.RoomSnapshotJson ?? "");
//         cmd.Parameters.AddWithValue("@insurance_snapshot_json", model.InsuranceSnapshotJson ?? "");
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




//     public async Task<ReturnData> DeleteAsync(int bookingId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_booking_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_id", bookingId);

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
