using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VSATicket.Application.Features.Tickets.ChangeTicketStatus;
using VSATicket.Application.Features.Tickets.CreateTicket;
using VSATicket.Application.Features.Tickets.DeleteTicket;
using VSATicket.Application.Features.Tickets.GetTicket;
using VSATicket.Application.Features.Tickets.ResolveTicket;
using VSATicket.Application.Features.Users.LoginUser;
using VSATicket.Application.Features.Users.RegisterUser;
using VSATicket.Application.Interfaces;
using VSATicket.Domain.Common.Models;
using VSATicket.Infrastructure.Configuration;
using VSATicket.Infrastructure.Data;
using VSATicket.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VSATicket API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserHandler>();
builder.Services.AddScoped<LoginUserHandler>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<GetTicketHandler>();
builder.Services.AddScoped<CreateTicketHandler>();
builder.Services.AddScoped<DeleteTicketHandler>();
builder.Services.AddScoped<ChangeTicketStatusHandler>();
builder.Services.AddScoped<ResolveTicketHandler>();

var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsSection);
var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

if (string.IsNullOrWhiteSpace(jwtSettings.SecretKey) || jwtSettings.SecretKey.Length < 16)
{
    throw new ArgumentException("JWT SecretKey must be at least 16 characters long.");
}

var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VSATicket API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    var roles = new[] { "admin", "user" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminUser = new AppUser
    {
        UserName = "adminUser",
        Email = "admin@example.com"
    };
    if (userManager.Users.All(u => u.UserName != adminUser.UserName))
    {
        var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "admin");
        }
    }

    var basicUser = new AppUser
    {
        UserName = "basicUser",
        Email = "user@example.com"
    };
    if (userManager.Users.All(u => u.UserName != basicUser.UserName))
    {
        var result = await userManager.CreateAsync(basicUser, "UserPassword123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(basicUser, "user");
        }
    }
}

app.Run();
