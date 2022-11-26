using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Persistence.Context;

namespace UsersApi.IoC.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddDependenciesConfiguration(this IServiceCollection services)
        {
            AddAutoMapperConfiguration(services);
            AddMediatorConfiguration(services);
            AddEFCoreConfiguration(
                services, 
                "Server=localhost;Database=UsersApi;Trusted_Connection=True;"
            );
        }

        private static IServiceCollection AddAutoMapperConfiguration(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection AddEFCoreConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UsersApiContext>(options =>
                options.UseSqlServer(connectionString)
            );
            return services;
        }
    }
}
