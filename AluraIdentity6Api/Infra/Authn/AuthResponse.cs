namespace AluraIdentity6Api.Infra.Authn;

public record AuthResponse
{
    public required string Token { get; init; }
    public required DateTime Expiration { get; init; }
}
