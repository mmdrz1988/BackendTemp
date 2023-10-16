using DPEprojectTask.Application.Contracts;
using DPEprojectTask.Application.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace DPEprojectTask.Application.Extensions
{
    public static class ServiceRegistrationExtensions
    {

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAddProductCommandFactory , AddProductCommandFactory>();

        }

    }
}
