using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.App.Validations;
using Microsoft.AspNetCore.Identity;

namespace AluraIdentity6Api.App.Services;

public class UserService : IModelService<AppUser>
{
    private readonly UserManager<AppUser> _manager;

    public UserService(UserManager<AppUser> manager)
    {
        _manager = manager;
    }

    public async Task<ServiceResult<AppUser>> CreateAsync(AppUser entity)
    {
        ValidCpfSpecification firstSpec = new();

        if (!firstSpec.IsSatisfiedBy(entity)) 
            return ServiceResult<AppUser>.Fail(["CPF Inválido"]);

        var result = await _manager.CreateAsync(entity);

        if (result.Succeeded)
            return ServiceResult<AppUser>.Ok(entity);

        return ServiceResult<AppUser>.Fail(result.Errors.Select(e => e.Description));
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
