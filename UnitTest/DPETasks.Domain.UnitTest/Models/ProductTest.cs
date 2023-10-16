using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.Exceptions;
using DPEprojectTask.Domain.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.Domain.UnitTest.Models
{
    public class ProductTest
    {
        [Fact]
        public void Should_ThrowAnException_When_ProductIsVisible()
        {
            // Arrange
            var product = new Product(0, "title", "body", DateTime.Now, 120, "imagePath", "FilePath", 2, true, false, true);
            // Act
            // Assert
            Assert.Throws<VisibleProductCannotBeDeletedException>(() => product.Delete());
        }

        [Fact]
        public void Should_Delete_When_ProductIsNotVisible()
        {
            // Arrange
            var product = new Product(0, "title", "body", DateTime.Now, 120, "imagePath", "FilePath", 2, false, false, true);
            // Act
            product.Delete();
            // Assert
            Assert.True(product.IsDeleted);
        }


        [Fact]
        public void Should_ThrowAnException_When_UpdatePriceMoreThanTenPercent()
        {
            // Arrange
            var product = new Product(0, "title", "body", DateTime.Now, 10, "imagePath", "FilePath", 2, false, false, true);
            // Act
            var updateProductCommand = new UpdateProductCommand()
            {
                Price = 15
            };
            // Assert
            Assert.Throws<UpdatedPriceCanNotBeMoreThanTenPercentException>(() => product.update(updateProductCommand));
        }

        [Fact]
        public void Should_UpdateTheProduct_When_UpdatePriceLessThanTenPercent()
        {
            // Arrange
            var product = new Product(0, "title", "body", DateTime.Now, 15, "imagePath", "FilePath", 2, true, false, true);
            var updateProductCommand = new UpdateProductCommand()
            {
                Price = 16
            };
            // Act
            product.update(updateProductCommand);

            // Assert
            Assert.Equal(product.Price, updateProductCommand.Price);
        }
    }
}
