using DAL.Data;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using DAL.UnitsOfWork.Abstract;
using DTO.Models.Abstract;

namespace DAL.UnitsOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly TradingCompanyContext context;

    private readonly Dictionary<Type, object> repositories = new();

    public UnitOfWork(TradingCompanyContext context_) => context = context_;

    public IRepository<T> GetRepository<T>() where T : EntityBase
    {
        if (repositories.ContainsKey(typeof(T)))
            return (IRepository<T>) repositories[typeof(T)];

        var repository = new GenericRepository<T>(context);
        repositories.Add(typeof(T), repository);
        return repository;
    }

    public void Commit() => context.SaveChanges();
}
