using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;

namespace WebApplication11.Core.Services;

public class ProductService : IProductService
{
    private IDataProvide _dataProvider;
    private ILogger _logger;
    
    public ProductService(ILogger logger, IDataProvide dataProvider)
    {
        _logger = logger;
        _dataProvider = dataProvider;
    }
    
    public int Create(Product product)
    {
        return _dataProvider.Create(product);
    }

    public Product Get(int id)
    {
        return _dataProvider.Select(id);
    }

    public void Update(Product product)
    {
        _dataProvider.Update(product);
    }

    public bool Delete(int id)
    {
        var product =  _dataProvider.Select(id);
        if (product != null)
        {
            _dataProvider.Delete(id);
            return true;
        }

        return false;
    }
}