// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataBookingPaymentCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataBookingPaymentCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }


//     public async Task<ReturnData> CreateAsync(BookingPaymentCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpayment_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@payment_method", model.PaymentMethod ?? "");
//         cmd.Parameters.AddWithValue("@payment_channel", model.PaymentChannel ?? "");
//         cmd.Parameters.AddWithValue("@amount_room", model.AmountRoom);
//         cmd.Parameters.AddWithValue("@amount_tax", model.AmountTax);
//         cmd.Parameters.AddWithValue("@amount_service_fee", model.AmountServiceFee);
//         cmd.Parameters.AddWithValue("@amount_insurance", model.AmountInsurance);
//         cmd.Parameters.AddWithValue("@total_amount", model.TotalAmount);
//         cmd.Parameters.AddWithValue("@payment_status", model.PaymentStatus ?? "");
//         cmd.Parameters.AddWithValue("@paid_at", model.PaidAt ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@created_at", model.CreatedAt);
//         cmd.Parameters.AddWithValue("@payment_code", model.PaymentCode ?? "");
//         cmd.Parameters.AddWithValue("@is_adjustment", model.IsAdjustment);
//         cmd.Parameters.AddWithValue("@adjustment_type", model.AdjustmentType ?? "");
//         cmd.Parameters.AddWithValue("@amount_discount", model.AmountDiscount);
//         cmd.Parameters.AddWithValue("@amount_admin_fee", model.AmountAdminFee);
//         cmd.Parameters.AddWithValue("@currency", model.Currency ?? "");
//         cmd.Parameters.AddWithValue("@gateway_reference_no", model.GatewayReferenceNo ?? "");
//         cmd.Parameters.AddWithValue("@gateway_response_json", model.GatewayResponseJson ?? "");
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
//         int paymentId,
//         BookingPaymentCrud model,
//         CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpayment_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@payment_id", paymentId);
//         cmd.Parameters.AddWithValue("@booking_id", model.BookingId);
//         cmd.Parameters.AddWithValue("@payment_method", model.PaymentMethod ?? "");
//         cmd.Parameters.AddWithValue("@payment_channel", model.PaymentChannel ?? "");
//         cmd.Parameters.AddWithValue("@amount_room", model.AmountRoom);
//         cmd.Parameters.AddWithValue("@amount_tax", model.AmountTax);
//         cmd.Parameters.AddWithValue("@amount_service_fee", model.AmountServiceFee);
//         cmd.Parameters.AddWithValue("@amount_insurance", model.AmountInsurance);
//         cmd.Parameters.AddWithValue("@total_amount", model.TotalAmount);
//         cmd.Parameters.AddWithValue("@payment_status", model.PaymentStatus ?? "");
//         cmd.Parameters.AddWithValue("@paid_at", model.PaidAt ?? (object)DBNull.Value);
//         cmd.Parameters.AddWithValue("@created_at", model.CreatedAt);
//         cmd.Parameters.AddWithValue("@payment_code", model.PaymentCode ?? "");
//         cmd.Parameters.AddWithValue("@is_adjustment", model.IsAdjustment);
//         cmd.Parameters.AddWithValue("@adjustment_type", model.AdjustmentType ?? "");
//         cmd.Parameters.AddWithValue("@amount_discount", model.AmountDiscount);
//         cmd.Parameters.AddWithValue("@amount_admin_fee", model.AmountAdminFee);
//         cmd.Parameters.AddWithValue("@currency", model.Currency ?? "");
//         cmd.Parameters.AddWithValue("@gateway_reference_no", model.GatewayReferenceNo ?? "");
//         cmd.Parameters.AddWithValue("@gateway_response_json", model.GatewayResponseJson ?? "");
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



//     public async Task<ReturnData> DeleteAsync(int paymentId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_bookingpayment_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@payment_id", paymentId);

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