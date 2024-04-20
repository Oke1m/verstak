using Tspu.Models;

namespace Tspu.Service;

public interface IProductsService
{
    List<Product> Get();
    Product? Get(Guid id);
    bool Add(Product product);
    bool Update(Product product);
    bool Delete(Guid id);
}
