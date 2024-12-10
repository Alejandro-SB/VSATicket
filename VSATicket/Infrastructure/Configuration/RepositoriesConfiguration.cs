using Microsoft.Extensions.DependencyInjection;
using VSATicket.Application.Interfaces;
using VSATicket.Infrastructure.Repositories;

namespace VSATicket.Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
