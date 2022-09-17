using Microsoft.Extensions.Options;
using WebApplication11.Core.Configuration;
using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;

namespace WebApplication11.Infrastructure;

public class DataProvider : IDataProvide
{
    private readonly List<Product> _storage;
    private int _idCount;

    public DataProvider()
    {
        _storage = new List<Product>();
        _idCount = 0;
    }
    
    public int Create(Product product)
    {
        product.Id = _idCount;
        _storage.Add(product);
        _idCount++;
        return product.Id;
    }

    public Product Select(int id)
    {
        return _storage.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Product product)
    {
        int index = _storage.FindIndex(x => x.Id == product.Id);
        _storage[index] = product;
    }

    public void Delete(int id)
    {
        int index = _storage.FindIndex(x => x.Id == id);
        _storage.RemoveAt(index);
    }
}