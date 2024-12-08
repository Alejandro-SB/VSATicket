using Microsoft.Extensions.DependencyInjection;
using VSATicket.Application.Features.Tickets.ChangeTicketStatus;
using VSATicket.Application.Features.Tickets.CreateTicket;
using VSATicket.Application.Features.Tickets.DeleteTicket;
using VSATicket.Application.Features.Tickets.GetTicket;
using VSATicket.Application.Features.Tickets.GetTicketsByCreator;
using VSATicket.Application.Features.Tickets.GetTicketsByStatus;
using VSATicket.Application.Features.Tickets.ResolveTicket;
using VSATicket.Application.Features.Users.LoginUser;
using VSATicket.Application.Features.Users.RegisterUser;

namespace VSATicket.Infrastructure.Configuration
{
    public static class HandlersConfiguration
    {
        public static IServiceCollection AddHandlersConfiguration(this IServiceCollection services)
        {
            services.AddScoped<RegisterUserHandler>();
            services.AddScoped<LoginUserHandler>();
            services.AddScoped<GetTicketHandler>();
            services.AddScoped<CreateTicketHandler>();
            services.AddScoped<DeleteTicketHandler>();
            services.AddScoped<ChangeTicketStatusHandler>();
            services.AddScoped<ResolveTicketHandler>();
            services.AddScoped<GetTicketsByStatusHandler>();
            services.AddScoped<GetTicketsByCreatorHandler>();

            return services;
        }
    }
}
