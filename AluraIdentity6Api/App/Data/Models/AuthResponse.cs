namespace AluraIdentity6Api.App.Data.Models;

public record AuthResponse
{
    public required string Token { get; init; }
    public required DateTime Expiration { get; init; }
}
