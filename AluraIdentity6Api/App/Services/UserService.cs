using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services.Interfaces;

namespace AluraIdentity6Api.App.Services;

public class UserService : IModelService<AppUser>
{
    public Task<ServiceResult<AppUser>> CreateAsync(AppUser entity)
    {
        throw new NotImplementedException();
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
