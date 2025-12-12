// using System.Data;
// using BackEnd.Models;
// using Microsoft.Data.SqlClient;
// using back_end.models;
// namespace BackEnd.AccessData;

// public class DataInsuranceCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataInsuranceCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(InsuranceCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_insurance_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@insurance_code", model.InsuranceCode ?? "");
//         cmd.Parameters.AddWithValue("@name", model.Name ?? "");
//         cmd.Parameters.AddWithValue("@description", model.Description ?? "");
//         cmd.Parameters.AddWithValue("@premium_type", model.PremiumType ?? "");
//         cmd.Parameters.AddWithValue("@premium_value", model.PremiumValue);
//         cmd.Parameters.AddWithValue("@provider_name", model.ProviderName ?? "");
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



//     public async Task<ReturnData> UpdateAsync(int insuranceId, InsuranceCrud model, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_insurance_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@insurance_id", insuranceId);
//         cmd.Parameters.AddWithValue("@insurance_code", model.InsuranceCode ?? "");
//         cmd.Parameters.AddWithValue("@name", model.Name ?? "");
//         cmd.Parameters.AddWithValue("@description", model.Description ?? "");
//         cmd.Parameters.AddWithValue("@premium_type", model.PremiumType ?? "");
//         cmd.Parameters.AddWithValue("@premium_value", model.PremiumValue);
//         cmd.Parameters.AddWithValue("@provider_name", model.ProviderName ?? "");
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



//     public async Task<ReturnData> DeleteAsync(int insuranceId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_insurance_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@insurance_id", insuranceId);

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
