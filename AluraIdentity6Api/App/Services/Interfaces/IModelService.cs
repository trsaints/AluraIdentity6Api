using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Data.Models.Interfaces;

namespace AluraIdentity6Api.App.Services.Interfaces;

public interface IModelService<T> where T : ITrackable
{
    Task<ServiceResult<T>> CreateAsync(T entity);
    Task<ServiceResult<T>> UpdateAsync(T entity);
    Task<ServiceResult<T>> DeleteAsync(int id);
    Task<ServiceResult<T>> GetByIdAsync(int id);
    Task<ServiceResult<IEnumerable<T>>> GetAllAsync();
}
