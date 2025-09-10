using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.Infra.Data.Constants;
using AluraIdentity6Api.Infra.Data.Database;
using AluraIdentity6Api.Infra.Data.Mappers;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;
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
        services.AddScoped<IModelService<AppUser>, UserService>();
    }
}
