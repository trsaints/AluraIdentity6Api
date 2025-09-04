using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Data.Mappers;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;

namespace AluraIdentity6Api.Infra.Startup;

public static class StartupExtensions
{
    public static void AddDataMappers(this IServiceCollection services)
    {
        services.AddSingleton<IMapper<AppUser, CreateUserModel>, UserMapper>();
    }
}
