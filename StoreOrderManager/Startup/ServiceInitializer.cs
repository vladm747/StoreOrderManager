using BLL.AutoMapperProfiles;
using BLL.Services.DI.Abstract;
using DAL.Context;
using DAL.Infrastructure.DI.Abstract;
using DAL.Infrastructure.DI.Implementation;

namespace StoreOrderManager.Startup
{
    using BLL.Services.DI.Implementation;
    using Microsoft.EntityFrameworkCore;
    
    public static class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            RegisterCustomDependencies(services, configuration);
            RegisterSwagger(services);
            return services;
        }

        public static void RegisterCustomDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Northwind")));
            services.AddAutoMapper(typeof(OrderProfile));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
