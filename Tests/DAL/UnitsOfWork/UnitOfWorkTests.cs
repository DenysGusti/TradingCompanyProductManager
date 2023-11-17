using DAL.Data;
using DAL.Repositories.Concrete;
using DAL.UnitsOfWork.Abstract;
using DAL.UnitsOfWork.Concrete;
using DTO.Models.Concrete;
using static DAL.Data.OnStartup;

namespace Tests.DAL.UnitsOfWork;

[TestClass]
public class UnitOfWorkTests
{
    [TestMethod]
    public void Commit_Saves_Changes()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new TradingCompanyContext(DatabaseType.Testing));
        var productRepository = unitOfWork.GetRepository<Product>() as GenericRepository<Product>;

        Product pizza = new()
        {
            Name = "Pepperoni Pizza",
            Price = 10.00m,
            Category = new()
            {
                Name = "Food"
            }
        };

        productRepository!.Table.Add(pizza);
        unitOfWork.Commit();

        var result = productRepository.Table.Find(pizza.Id);
        Assert.IsNotNull(result);
    }
}