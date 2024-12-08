using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VSATicket.Domain.Common.Models;
using VSATicket.Infrastructure.Data;

namespace VSATicket.Infrastructure.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}
