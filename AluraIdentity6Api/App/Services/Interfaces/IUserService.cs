using AluraIdentity6Api.App.Data.Models;

namespace AluraIdentity6Api.App.Services.Interfaces;

public interface IUserService : IModelService<AppUser>
{
    Task<ServiceResult<AppUser>> CreateAsync(AppUser user, string password);

    Task<ServiceResult<AppUser>> LoginAsync(string email, string password);
}
