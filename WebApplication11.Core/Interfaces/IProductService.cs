using WebApplication11.Core.Entities;

namespace WebApplication11.Core.Interfaces;

public interface IProductService
{
    void Create(Product product);
    Product Get(int id);
    void Update(Product product);
    void Delete(int id);
}