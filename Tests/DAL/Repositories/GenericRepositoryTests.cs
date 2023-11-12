using DAL.Data;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using DTO.Models.Concrete;
using static DAL.Data.OnStartup;
using DAL.UnitsOfWork.Abstract;
using DAL.UnitsOfWork.Concrete;

namespace Tests.DAL.Repositories;

[TestClass]
public class GenericRepositoryTests
{
    [TestMethod]
    public void GetById_Returns_Entity_When_Found()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));

        Category food = new()
        {
            Name = "Food"
        };

        unitOfWork.GetRepository<Category>().Create(food);

        Product pizza = new()
        {
            Name = "Pepperoni Pizza",
            Price = 10.00m,
            Category = food
        };

        var productRepository = unitOfWork.GetRepository<Product>();
        productRepository.Create(pizza);
        unitOfWork.Commit();
        var result = productRepository.GetById(pizza.Id);

        Console.WriteLine(pizza);
        Console.WriteLine(result);
        Assert.AreEqual(pizza, result);

        var q = productRepository.GetAll().Where(p => p.Name == "Pepperoni Pizza");
    }
}