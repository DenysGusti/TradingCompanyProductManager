using Microsoft.Extensions.Configuration;

namespace DAL.Data;

public static class Startup
{
    public enum DatabaseType
    {
        Production, Testing
    }

    private static string JSONStringFromType(DatabaseType type) =>
        type switch
        {
            DatabaseType.Production => "ProductionDatabase",
            DatabaseType.Testing => "TestingDataDatabase",
            _ => throw new InvalidOperationException()
        };

    public static string? GetConnectionString(DatabaseType type)
    {
        DirectoryInfo directory = new(Directory.GetCurrentDirectory());

        var configuration = new ConfigurationBuilder()
            .SetBasePath(directory.Parent!.ToString())
        .AddJsonFile("appsettings.json")
        .Build();

        return configuration.GetConnectionString(JSONStringFromType(type));
    }
}
