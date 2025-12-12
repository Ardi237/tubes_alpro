    using System.Data;
    using BackEnd.Models;
    using BackEnd.Helper;
    using Microsoft.Data.SqlClient;

    namespace BackEnd.AccessData;

    public class DataAdminList
    {
        private readonly SqlConnectionFactory _factory;

        public DataAdminList(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IReadOnlyList<AdminList>> FindAsync(string searchText, CancellationToken cancellationToken = default)
        {
            const string storedProc = "usp_admin_find";

            await using var conn = _factory.Create();
            await conn.OpenAsync(cancellationToken);

            using var cmd = new SqlCommand(storedProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@search_text", searchText ?? (object)DBNull.Value);

            var results = new List<AdminList>();
            await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                var model = new AdminList();

                // --- BARIS ERROR / INFO ---
                model.Success = reader.GetInt32(reader.GetOrdinal("success")) == 1;
                model.Message = reader.GetString(reader.GetOrdinal("message"));

                // --- JIKA ADA DATA DETAIL (kolom > 2) ---
                if (reader.FieldCount > 2)
                {
                    model.AdminId   = reader.GetInt64(reader.GetOrdinal("admin_id"));
                    model.FullName  = reader.GetString(reader.GetOrdinal("full_name"));
                    model.Email     = reader.GetString(reader.GetOrdinal("email"));
                    model.Role      = reader.GetString(reader.GetOrdinal("role"));
                    model.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                    model.IsActive  = reader.GetBoolean(reader.GetOrdinal("is_active"));
                }

                results.Add(model);
            }

            return results;
        }


    public async Task<List<AdminList>> ListAsync(long? adminId = null, CancellationToken cancellationToken = default)
    {
        const string storedProc = "usp_admin_list";

        await using var conn = _factory.Create();
        await conn.OpenAsync(cancellationToken);

        using var cmd = new SqlCommand(storedProc, conn)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@admin_id", adminId ?? (object)DBNull.Value);

        var results = new List<AdminList>();
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            var model = new AdminList();

            model.Success = reader.GetInt32(reader.GetOrdinal("success")) == 1;
            model.Message = reader.GetString(reader.GetOrdinal("message"));

            if (reader.FieldCount > 2)
            {
                model.AdminId   = reader.GetInt64(reader.GetOrdinal("admin_id"));
                model.FullName  = reader.GetString(reader.GetOrdinal("full_name"));
                model.Email     = reader.GetString(reader.GetOrdinal("email"));
                model.Role      = reader.GetString(reader.GetOrdinal("role"));
                model.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                model.IsActive  = reader.GetBoolean(reader.GetOrdinal("is_active"));
            }

            results.Add(model);
        }

        return results;
    }

}
