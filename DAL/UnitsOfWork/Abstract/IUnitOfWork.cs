using DAL.Repositories.Abstract;
using DTO.Models.Abstract;

namespace DAL.UnitsOfWork.Abstract;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : EntityBase;

    public void Commit();
}
