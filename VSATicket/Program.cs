using Microsoft.EntityFrameworkCore;
using VSATicket.Application.Features.Tickets.ChangeTicketStatus;
using VSATicket.Application.Features.Tickets.CreateTicket;
using VSATicket.Application.Features.Tickets.DeleteTicket;
using VSATicket.Application.Features.Tickets.GetTicket;
using VSATicket.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<GetTicketHandler>();
builder.Services.AddScoped<CreateTicketHandler>();
builder.Services.AddScoped<DeleteTicketHandler>();
builder.Services.AddScoped<ChangeTicketStatusHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
