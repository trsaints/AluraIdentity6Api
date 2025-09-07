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
            Cpf = value.Cpf,
            FullName = value.FullName,
            UserName = value.UserName,
            BirthDate = value.BirthDate,
            Email = value.UserName,
        };

        return result;
    }

    public CreateUserModel? ToRequestModel(AppUser model)
    {
        CreateUserModel result = new()
        {
            Cpf = model.Cpf,
            FullName = model.FullName,
            UserName = model.UserName ?? string.Empty,
            BirthDate = model.BirthDate ?? DateTime.MinValue,
            Password = null!,
            ConfirmPassword = null!
        };

        return result;
    }
}
