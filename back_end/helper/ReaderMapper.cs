using System.Data;
using System.Reflection;
using Newtonsoft.Json;

namespace BackEnd.Helper
{
    public static class ReaderMapper
    {
        public static T MapTo<T>(this IDataRecord record) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);

            int matchCount = 0;

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new
                {
                    Property = p,
                    JsonName = p.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName,
                    Name = p.Name
                })
                .ToList();

            for (int i = 0; i < record.FieldCount; i++)
            {
                string columnName = record.GetName(i);

                var match = properties.FirstOrDefault(x =>
                    string.Equals(x.JsonName, columnName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(x.Name, columnName, StringComparison.OrdinalIgnoreCase)
                );

                if (match == null || !match.Property.CanWrite)
                    continue;

                matchCount++;

                object? value = record.IsDBNull(i) ? null : record.GetValue(i);

                try
                {
                    object? safeValue = Convert.ChangeType(
                        value,
                        Nullable.GetUnderlyingType(match.Property.PropertyType) ??
                        match.Property.PropertyType
                    );

                    match.Property.SetValue(obj, safeValue);
                }
                catch
                {
                    if (match.Property.PropertyType == typeof(bool) ||
                        match.Property.PropertyType == typeof(bool?))
                    {
                        match.Property.SetValue(obj, value?.ToString() == "1");
                    }
                }
            }

            if (matchCount <= 2)
                throw new InvalidOperationException("ROW_ERROR_STRUCTURE");

            return obj;
        }
    }
}