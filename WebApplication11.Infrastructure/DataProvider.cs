using Microsoft.Extensions.Options;
using WebApplication11.Core.Configuration;
using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;

namespace WebApplication11.Infrastructure;

public class DataProvider : IDataProvide
{
    private readonly List<Product> _storage;
    private readonly DataProviderOptions _dataProviderOptions;
    private int _idCount;

    public DataProvider(IOptions<DataProviderOptions> dataProviderOptions)
    {
        _storage = new List<Product>();
        _dataProviderOptions = dataProviderOptions.Value;
        _idCount = 0;
    }
    
    public void Create(Product product)
    {
        product.Id = _idCount;
        _storage.Add(product);
        _idCount++;
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