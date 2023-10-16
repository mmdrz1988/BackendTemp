using DPETasks.Core.Common.Contracts;
using DPETasks.FileService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.FileService.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void RegisterFileServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IFileSystem, FileSystem>();

        }
    }
}
