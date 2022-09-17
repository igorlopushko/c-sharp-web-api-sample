using System.Collections.Generic;
using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;

namespace WebApplication11.Core.Tests;

public class MockDataProvider : IDataProvide
{
    public List<Product> _data = new List<Product>();

    public int Create(Product product)
    {
        _data.Add(product);
        return 0;
    }

    public Product Select(int id)
    {
        return new Product("T-Shirt", 9.99M);
    }

    public void Update(Product product)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
        return;
    }
}