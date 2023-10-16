using DPEprojectTask.Application.Extensions;
using DPEprojectTask.Application.Handlers.OrderHandler;
using DPEprojectTask.Application.Handlers.ProductHandler;
using DPEprojectTask.Application.IServices;
using DPEprojectTask.Application.Services;
using DPEprojectTask.Domain.Commands.Orders;
//using DPEprojectTask.Domain.Commands.Orders;
using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Infrastructure.DbContexts;
using DPEprojectTask.Infrastructure.Repositories;
using DPETasks.FileService.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DPEProject.API.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
           WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            builder.Services.AddControllers();
            

            //----------------db context Injection ---------//
            builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(@"Data Source=.;Initial Catalog=DPEProject;Encrypt=false;Integrated Security=True;Trust Server Certificate=true"));

            //---------- AddRepository Injection------------//
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            


            //---------- AddMediatR ------------//
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // AddProduct Handler
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly);
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddProductHandler).Assembly);
            });
            // UpdateProduct Handler
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommand).Assembly);
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly);
            });

            // Order Handler
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddOrderCommand).Assembly);
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddOrderCommandHandler).Assembly);
            });

            //----------------------Add other Layer Services
            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterFileServiceServices();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
              
            return services;
        }
    }

    public static class CreateHostBuilderClass
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                          .UseContentRoot("Uploads")
                          .UseStartup<IStartup>();
                })
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var env = builderContext.HostingEnvironment;
                    config
                     .AddJsonFile("appsettings.json", false, true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, true)
                     .AddEnvironmentVariables();
                });

        }



    }
}
