using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.Infra.Authn;
using AluraIdentity6Api.Infra.Authn.Interfaces;
using AluraIdentity6Api.Infra.Data.Constants;
using AluraIdentity6Api.Infra.Data.Database;
using AluraIdentity6Api.Infra.Data.Mappers;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AluraIdentity6Api.Infra.Startup;

public static class StartupExtensions
{
    public static void AddDataMappers(this IServiceCollection services)
    {
        services.AddSingleton<IMapper<AppUser, CreateUserModel>, UserMapper>();
    }

    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppDbConstants.DefaultConnectionStringName) 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }

    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthnService, AuthnService>();
    }

    /// <summary>
    /// Configura as opções do Identity para a aplicação, incluindo requisitos de senha,
    /// bloqueio de conta, caracteres permitidos no nome de usuário, exigência de e-mail único
    /// e confirmação de e-mail para login.
    /// </summary>
    /// <param name="services">A coleção de serviços da aplicação.</param>
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });
    }
}
