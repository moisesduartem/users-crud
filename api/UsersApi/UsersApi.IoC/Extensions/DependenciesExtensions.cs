using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace UsersApi.IoC.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddDependenciesConfiguration(this IServiceCollection services)
        {
            AddAutoMapperConfiguration(services);
            AddMediatorConfiguration(services);
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
    }
}
