using DTO.Models.Abstract;

namespace DAL.Repositories.Abstract;

public interface IRepository<T> where T : EntityBase
{
    T? GetById(int id);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    T[] GetAll();
}
