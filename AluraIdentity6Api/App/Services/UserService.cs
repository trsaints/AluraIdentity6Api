using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.App.Validations;
using Microsoft.AspNetCore.Identity;

namespace AluraIdentity6Api.App.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _manager;

    public UserService(UserManager<AppUser> manager)
    {
        _manager = manager;
    }

    public async Task<ServiceResult<AppUser>> CreateAsync(AppUser user, string password)
    {
        ValidCpfSpecification firstSpec = new();
        MinRequiredAgeSpecification secondSpec = new();

        if (!firstSpec.IsSatisfiedBy(user))
            return ServiceResult<AppUser>.Fail(["CPF Inválido"]);

        if (!secondSpec.IsSatisfiedBy(user))
            return ServiceResult<AppUser>.Fail(["Usuário deve ter no mínimo 21 anos"]);

        var result = await _manager.CreateAsync(user, password);

        if (result.Succeeded)
            return ServiceResult<AppUser>.Ok(user);

        return ServiceResult<AppUser>.Fail(result.Errors.Select(e => e.Description));
    }

    public Task<ServiceResult<AppUser>> CreateAsync(AppUser entity)
    {
        throw new InvalidOperationException("Use o método Create(AppUser user, string password) para criar um usuário com senha.");
    }

    public Task<ServiceResult<AppUser>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<IEnumerable<AppUser>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<AppUser>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<AppUser>> UpdateAsync(AppUser entity)
    {
        throw new NotImplementedException();
    }
}
