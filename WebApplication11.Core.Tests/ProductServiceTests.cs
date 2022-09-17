using Moq;
using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;
using WebApplication11.Core.Services;
using Xunit;

namespace WebApplication11.Core.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void Create_ValidProduct_AddedToDatabase()
        {
            // Arrange
            WebApplication11.Core.Interfaces.ILogger logger = 
                Mock.Of<WebApplication11.Core.Interfaces.ILogger>(l => l.GetCurrentDirectory() == "C:\\Logs");
            
            Mock<IDataProvide> provider = new Mock<IDataProvide>();
            provider
                .Setup(p => p.Create(It.IsAny<Product>()))
                .Returns(0);

            var service = new ProductService(logger, provider.Object);
            var product = new Product("T-Shirt", (decimal)9.99);

            // Act
            var id = service.Create(product);

            // Assert
            Assert.Equal(0, id);
            provider.Verify(p => p.Create(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void Delete_ValidProduct_IsProductDeleted()
        {
            // Arrange
            WebApplication11.Core.Interfaces.ILogger logger = 
                Mock.Of<WebApplication11.Core.Interfaces.ILogger>(l => l.GetCurrentDirectory() == "C:\\Logs");
            var service = new ProductService(logger, new MockDataProvider());
            var product = new Product("T-Shirt", (decimal)9.99);
            

            // Act
            var id = service.Create(product);
            var isDeleted = service.Delete(id);
            //var result = service.Get(id);

            // Assert
            Assert.True(isDeleted);
            //Assert.Null(result);
        }
    }
}