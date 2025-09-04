using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;

namespace AluraIdentity6Api.Infra.Data.Mappers;

public class UserMapper : IMapper<AppUser, CreateUserModel>
{
    public AppUser? ToDomainModel(CreateUserModel value)
    {
        AppUser result = new()
        {
        };

        return result;
    }

    public CreateUserModel? ToRequestModel(AppUser model)
    {
        CreateUserModel result = new()
        {
        };

        return result;
    }
}
