using DAL.Data;
using DAL.Repositories.Abstract;
using DTO.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly TradingCompanyContext context;

        private readonly DbSet<T> dbSet;

        public GenericRepository(TradingCompanyContext context_) {
            context = context_;
            dbSet = context.Set<T>();
        }

        public void Create(T entity) => dbSet.Add(entity);

        public void Delete(T entity) => dbSet.Remove(entity);

        public T[] GetAll() => dbSet.ToArray();

        public T? GetById(int id) => dbSet.Find(id);

        public void Update(T entity) => dbSet.Update(entity);

        public DbSet<T> Table => dbSet;
    }
}
