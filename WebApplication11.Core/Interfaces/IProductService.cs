using WebApplication11.Core.Entities;

namespace WebApplication11.Core.Interfaces;

public interface IProductService
{
    int Create(Product product);
    Product Get(int id);
    void Update(Product product);
    bool Delete(int id);
}