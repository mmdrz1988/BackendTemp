using DPETasks.Core.Common.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.FileService.Services
{
    public class ProductImageService: IProductImageService
    {

        private readonly string _rootPath;
        private readonly IFileSystem _fileSystem;

        public ProductImageService(IFileSystem fileSystem , IWebHostEnvironment env)
        {
            _fileSystem = fileSystem;
             _rootPath = Path.Combine(env.WebRootPath, "ProduceImage");
            //"

            if (!Directory.Exists(_rootPath))
                Directory.CreateDirectory(_rootPath); 
        }
        public ProductImageService()
        {
        }

        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var filePath =Path.Combine(_rootPath,Guid.NewGuid()+""+file.FileName);
            var FileStreamToSave = _fileSystem.File.Create(filePath);  
            
            await file.CopyToAsync(FileStreamToSave);
            FileStreamToSave.Close();
            return filePath;
        }


    }
}
