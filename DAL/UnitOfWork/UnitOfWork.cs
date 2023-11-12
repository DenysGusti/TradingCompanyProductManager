using DAL.Data;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using DTO.Models.Concrete.Generated;
using static DAL.Data.Startup;

namespace DAL.UnitOfWork;

public class UnitOfWork
{
    private readonly ProductManagerContext context;

    public UnitOfWork(DatabaseType type) => context = new(type);

    private IRepository<Category> categoryRepository = null!;

    private IRepository<Product> productRepository = null!;

    public IRepository<Category> CategoryRepository
        => categoryRepository ??= new GenericRepository<Category>(context);

    public IRepository<Product> ProductRepository
        => productRepository ??= new GenericRepository<Product>(context);

    public void Save() => context.SaveChanges();
}
