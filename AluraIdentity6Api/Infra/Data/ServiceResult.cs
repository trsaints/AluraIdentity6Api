using AluraIdentity6Api.App.Data.Models.Interfaces;

namespace AluraIdentity6Api.App.Data.Models;

public class ServiceResult<T> : IServiceResult<T>
{
    public bool Succeeded { get; init; }

    public IEnumerable<string>? Errors { get; init; }

    public T? Data { get; init; }

    public static ServiceResult<T> Fail(IEnumerable<string> errors)
    {
        return new ServiceResult<T>()
        {
            Succeeded = false,
            Data = default,
            Errors = errors
        };
    }

    public static ServiceResult<T> Ok(T data)
    {
        return new ServiceResult<T>()
        {
            Succeeded = true,
            Data = data,
            Errors = null
        };
    }
}
