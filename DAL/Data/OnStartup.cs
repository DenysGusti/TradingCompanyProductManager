using Microsoft.Extensions.Configuration;

namespace DAL.Data;

public static class OnStartup
{
    public enum DatabaseType
    {
        Production, Testing
    }

    private static string JSONStringFromType(DatabaseType type) =>
        type switch
        {
            DatabaseType.Production => "ProductionDatabase",
            DatabaseType.Testing => "TestingDatabase",
            _ => throw new InvalidOperationException()
        };

    public static string? GetConnectionString(DatabaseType type)
    {
        DirectoryInfo directory = new(Directory.GetCurrentDirectory());

        var configuration = new ConfigurationBuilder()
            .SetBasePath(directory.Parent!.Parent!.Parent!.Parent!.ToString())
            .AddJsonFile("appsettings.json")
            .Build();

        return configuration.GetConnectionString(JSONStringFromType(type));
    }
}
