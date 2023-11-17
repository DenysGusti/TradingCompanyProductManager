using DAL.Data;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using DTO.Models.Concrete;
using static DAL.Data.OnStartup;
using DAL.UnitsOfWork.Abstract;
using DAL.UnitsOfWork.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Tests.DAL.Repositories;

[TestClass]
public class GenericRepositoryTests
{
    [TestMethod]
    public void GetById_Returns_Entity_When_Found()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));
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
        unitOfWork.Database.SaveChanges();

        var result = productRepository.GetById(pizza.Id);
        Assert.AreEqual(pizza, result);
    }

    [TestMethod]
    public void Create_Creates_Entity()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));
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

        productRepository!.Create(pizza);
        unitOfWork.Database.SaveChanges();

        var result = productRepository.Table.Find(pizza.Id);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void GetAll_Finds_Entities()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));
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
        unitOfWork.Database.SaveChanges();

        var result = productRepository
            .GetAll()
            .Where(p => p.Name == "Pepperoni Pizza");
        Assert.AreNotEqual(result.Count(), 0);
    }

    [TestMethod]
    public void Update_Modifies_Entity()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));
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
        unitOfWork.Database.SaveChanges();

        pizza.Price = 12.00m;
        Thread.Sleep(1000);
        pizza.LastModifiedOn = DateTime.Now;
        productRepository.Update(pizza);
        unitOfWork.Database.SaveChanges();

        var result = productRepository.Table.Find(pizza.Id);

        Assert.AreEqual(result!.Price, 12.00m);
    }

    [TestMethod]
    public void Delete_Deletes_Entities()
    {
        UnitOfWork unitOfWork = new(new TradingCompanyContext(DatabaseType.Testing));
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
        unitOfWork.Database.SaveChanges();

        foreach (var product in productRepository!.Table)
        {
            productRepository.Delete(product);
        }
        var categoryRepository = unitOfWork.GetRepository<Category>() as GenericRepository<Category>;
        foreach (var category in categoryRepository!.Table)
        {
            categoryRepository.Delete(category);
        }
        unitOfWork.Database.SaveChanges();

        var result = productRepository.Table.Find(pizza.Id);
        Assert.IsNull(result);
    }
}