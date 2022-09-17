using System;
using Moq;
using WebApplication11.Controllers;
using WebApplication11.Core.Entities;
using WebApplication11.Core.Interfaces;
using Xunit;

namespace WebApplication11.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Get_ValidProduct_ReturnProduct()
        {
            // Arrange
            Mock<IProductService> mockService = new Mock<IProductService>();
            mockService
                .Setup(s => s.Get(It.IsAny<int>()))
                .Returns(new Product("T-Shirt", 9.99M));
            var controller = new ProductController(mockService.Object);

            // Act
            var product = controller.Get(0);

            // Assert
            Assert.NotNull(product);
            mockService.Verify(s => s.Get(It.IsAny<int>()), Times.Once);
        }
    }
}