namespace AluraIdentity6Api.App.Data.Models.Interfaces;

public interface IServiceResult<T>
{
    bool Succeeded { get; }
    IEnumerable<string>? Errors { get; }
    T? Data { get; }
    static abstract IServiceResult<T> Ok(T data);
    static abstract IServiceResult<T> Fail(IEnumerable<string> errors);
}
