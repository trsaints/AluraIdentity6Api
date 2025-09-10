namespace AluraIdentity6Api.App.Data.Models.Interfaces;

public interface IServiceResult<T>
{
    bool Succeeded { get; }
    IEnumerable<string>? Errors { get; }
    T? Data { get; }
}
