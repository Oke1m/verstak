using Dapper;
using Tspu.Models;

namespace Tspu.Service;

public class ProductsService : IProductsService
{
    private readonly DataContext dataContext;

    public ProductsService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public bool Add(Product product)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        using var connection = dataContext.CreateConnection();
        connection.Open();
        var affectedRows = connection.Execute($"delete from products pr where pr.id=@id", new
        {
            id = id,
        });
        return affectedRows == 1;
    }

    public List<Product> Get()
    {
        using var connection = dataContext.CreateConnection();
        connection.Open();
        var products = connection.Query<Product>("select * from products");
        return products.ToList();
    }

    public Product? Get(Guid id)
    {
        using var connection = dataContext.CreateConnection();
        connection.Open();
        var products = connection.Query<Product>("select * from products pr where pr.id=@id", new
        {
            id = id,
        });
        return products.FirstOrDefault();
    }

    public bool Update(Product product)
    {
        throw new NotImplementedException();
    }
}
