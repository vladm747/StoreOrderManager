using BLL.AutoMapperProfiles;
using DAL.Context;
using DAL.Infrustructure.DI.Abstract;
using DAL.Infrustructure.DI.Implementation;

namespace StoreOrderManager.Startup
{
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
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
