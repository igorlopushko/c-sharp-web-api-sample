using WebApplication11.Core.Entities;

namespace WebApplication11.Core.Interfaces;

public interface IDataProvide
{
    void Create(Product product);
    Product Select(int id);
    void Update(Product product);
    void Delete(int id);
}