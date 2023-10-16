using DPEprojectTask.Application.Factories;
using DPEPTask.Core.ViewModels;
using DPETasks.Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.Application.UnitTests.Factories
{
    public class AddProductCommandFactoryTest
    {
        private AddProductCommandFactory _addProductCommandFactory;
        public AddProductCommandFactoryTest()
        {
            var mockProductImageServices = new Mock<IProductImageService>();
            mockProductImageServices.Setup(x => x.SaveImageAsync(It.IsAny<IFormFile>()))
                .ReturnsAsync("UploadImagePath");
            _addProductCommandFactory = new AddProductCommandFactory(mockProductImageServices.Object);
        }

        [Fact]
        public async void Should_UploadImagePath_WhenFileSaved()
        {
            byte[] filebytes = Encoding.UTF8.GetBytes("dummy image");
            IFormFile file = new FormFile(new MemoryStream(filebytes), 0, filebytes.Length, "Data", "image.png");
            var addProductCommmandFactory = await _addProductCommandFactory.CreateAsync(new AddProductCommandModel()
            {
                File = file

            });
            string resultAsync = "UploadImagePath";
            Assert.Equal(addProductCommmandFactory.ImagePath, resultAsync);
        }

        [Fact]
        public async void Should_ThrownAnArgumentNullException_When_FileIsNotProvided()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _addProductCommandFactory.CreateAsync(new AddProductCommandModel()));
        }
    }
}
