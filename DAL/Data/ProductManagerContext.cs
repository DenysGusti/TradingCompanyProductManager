using DTO.Models.Concrete.Generated;
using Microsoft.EntityFrameworkCore;
using static DAL.Data.Startup;

namespace DAL.Data;

public class ProductManagerContext : DbContext
{
    private readonly string? connectionString;

    public ProductManagerContext(DatabaseType type = DatabaseType.Production)
        => connectionString = GetConnectionString(type);

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connectionString);
}
