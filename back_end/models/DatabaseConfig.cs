using DotNetEnv;

namespace BackEnd.Models;

public sealed class DatabaseConfig
{
    public string Host { get; }
    public int Port { get; }
    public string Name { get; }
    public bool Encrypt { get; }
    public bool TrustServerCertificate { get; }

    private DatabaseConfig(string host, int port, string name, bool encrypt, bool trustServerCertificate)
    {
        Host = host;
        Port = port;
        Name = name;
        Encrypt = encrypt;
        TrustServerCertificate = trustServerCertificate;
    }

    public static DatabaseConfig FromEnvironment()
    {
        LoadEnvFile();

        var host = Require("DB_HOST");
        var database = Require("DB_NAME");
        var port = ReadInt("DB_PORT", 1433);
        var encrypt = ReadBool("DB_ENCRYPT", true);
        var trustCert = ReadBool("DB_TRUST_CERT", true);

        return new DatabaseConfig(host, port, database, encrypt, trustCert);
    }

    private static void LoadEnvFile()
    {
        var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
        if (File.Exists(envPath))
        {
            Env.Load(envPath);
        }
        else
        {
            Env.Load();
        }
    }

    private static string Require(string key)
    {
        var value = Environment.GetEnvironmentVariable(key);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Missing required environment variable '{key}'.");
        }

        return value;
    }

    private static int ReadInt(string key, int fallback)
    {
        var raw = Environment.GetEnvironmentVariable(key);
        return int.TryParse(raw, out var parsed) ? parsed : fallback;
    }

    private static bool ReadBool(string key, bool fallback)
    {
        var raw = Environment.GetEnvironmentVariable(key);
        return raw switch
        {
            null => fallback,
            _ when bool.TryParse(raw, out var parsed) => parsed,
            _ => fallback
        };
    }
}
