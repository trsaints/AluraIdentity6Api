using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;

namespace AluraIdentity6Api.Infra.Data.Mappers;

public class UsuarioMapper : IMapper<AppUser, CreateUsuarioModel>
{
    public AppUser? ToDomainModel(CreateUsuarioModel value)
    {
        AppUser result = new()
        {
        };

        return result;
    }

    public CreateUsuarioModel? ToRequestModel(AppUser model)
    {
        CreateUsuarioModel result = new()
        {
        };

        return result;
    }
}
