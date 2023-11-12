using DTO.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using static DAL.Data.OnStartup;

namespace DAL.Data;

public class TradingCompanyContext : DbContext
{
    private readonly string? connectionString;

    public TradingCompanyContext(DatabaseType type)
        => connectionString = GetConnectionString(type);

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connectionString);
}
