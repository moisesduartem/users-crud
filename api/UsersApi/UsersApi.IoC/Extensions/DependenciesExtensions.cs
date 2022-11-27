using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Domain.Repositories;
using UsersApi.Persistence.Context;
using UsersApi.Persistence.Repositories;

namespace UsersApi.IoC.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddDependenciesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            AddDIConfiguration(services);
            AddAutoMapperConfiguration(services);
            AddMediatorConfiguration(services);
            AddEFCoreConfiguration(
                services, 
                configuration.GetConnectionString("SqlServer") ?? ""
            );
        }

        private static IServiceCollection AddDIConfiguration(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
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
