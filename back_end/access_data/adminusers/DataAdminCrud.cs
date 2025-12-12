// using System.Data;
// using BackEnd.Models;
// using back_end.models;
// using Microsoft.Data.SqlClient;

// namespace BackEnd.AccessData;

// public class DataAdminCrud
// {
//     private readonly SqlConnectionFactory _factory;

//     public DataAdminCrud(SqlConnectionFactory factory)
//     {
//         _factory = factory;
//     }

//     public async Task<ReturnData> CreateAsync(AdminCrud admin, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_admin_insert";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@full_name", admin.FullName ?? "");
//         cmd.Parameters.AddWithValue("@email", admin.Email ?? "");
//         cmd.Parameters.AddWithValue("@password_hash", admin.PasswordHash ?? "");
//         cmd.Parameters.AddWithValue("@role", admin.Role ?? "");

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             try
//             {
//                 int success  = Convert.ToInt32(reader["success"]);
//                 int message  = 0;
//                 int rowcount = reader["rows_affected"] != DBNull.Value
//                                 ? Convert.ToInt32(reader["rows_affected"])
//                                 : 0;

//                 if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                     message = parsed;

//                 return new ReturnData(success, message, rowcount);
//             }
//             catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
//             {
//                 return new ReturnData(
//                     reader.GetInt32(0),
//                     reader.GetInt32(1),
//                     0
//                 );
//             }
//         }

//         return new ReturnData(0, 0, 0);
//     }


//    public async Task<ReturnData> UpdateAsync(int adminId, AdminCrud admin, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_admin_update";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@admin_id", adminId);
//         cmd.Parameters.AddWithValue("@full_name", admin.FullName ?? "");
//         cmd.Parameters.AddWithValue("@email", admin.Email ?? "");
//         cmd.Parameters.AddWithValue("@password_hash", admin.PasswordHash ?? "");
//         cmd.Parameters.AddWithValue("@role", admin.Role ?? "");

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             try
//             {
//                 int success = Convert.ToInt32(reader["success"]);
//                 int message = 0;
//                 int rowcount = reader["rows_affected"] != DBNull.Value
//                                 ? Convert.ToInt32(reader["rows_affected"])
//                                 : 0;

//                 if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                     message = parsed;

//                 return new ReturnData(success, message, rowcount);
//             }
//             catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
//             {
//                 return new ReturnData(
//                     reader.GetInt32(0),
//                     reader.GetInt32(1),
//                     0
//                 );
//             }
//         }

//         return new ReturnData(0, 0, 0);
//     }



//     public async Task<ReturnData> DeleteAsync(int adminId, CancellationToken cancellationToken = default)
//     {
//         const string storedProc = "usp_admin_delete";

//         await using var conn = _factory.Create();
//         await conn.OpenAsync(cancellationToken);

//         using var cmd = new SqlCommand(storedProc, conn)
//         {
//             CommandType = CommandType.StoredProcedure
//         };

//         cmd.Parameters.AddWithValue("@admin_id", adminId);

//         using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

//         if (await reader.ReadAsync(cancellationToken))
//         {
//             try
//             {
//                 int success = Convert.ToInt32(reader["success"]);
//                 int message = 0;
//                 int rowcount = reader["rows_affected"] != DBNull.Value
//                                 ? Convert.ToInt32(reader["rows_affected"])
//                                 : 0;

//                 if (int.TryParse(reader["message"]?.ToString(), out var parsed))
//                     message = parsed;

//                 return new ReturnData(success, message, rowcount);
//             }
//             catch (InvalidOperationException ex) when (ex.Message == "ROW_ERROR_STRUCTURE")
//             {
//                 return new ReturnData(
//                     reader.GetInt32(0),
//                     reader.GetInt32(1),
//                     0
//                 );
//             }
//         }

//         return new ReturnData(0, 0, 0);
//     }

// }
