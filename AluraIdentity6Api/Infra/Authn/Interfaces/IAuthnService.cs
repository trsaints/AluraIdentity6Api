using AluraIdentity6Api.App.Data.Models;

namespace AluraIdentity6Api.Infra.Authn.Interfaces;

public interface IAuthnService
{
    public ServiceResult<AuthResponse> GenerateToken(AppUser user);
}
