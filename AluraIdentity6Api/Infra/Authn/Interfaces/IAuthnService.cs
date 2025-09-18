using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Data;

namespace AluraIdentity6Api.Infra.Authn.Interfaces;

public interface IAuthnService
{
    public ServiceResult<AuthResponse> GenerateToken(AppUser user);
}
