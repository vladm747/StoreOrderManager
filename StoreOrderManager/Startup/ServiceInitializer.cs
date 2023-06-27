using DAL.Context;

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
        }

        private static void RegisterSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
