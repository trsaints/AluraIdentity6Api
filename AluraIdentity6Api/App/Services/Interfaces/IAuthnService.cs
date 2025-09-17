using AluraIdentity6Api.App.Data.Models;
using System.IdentityModel.Tokens.Jwt;

namespace AluraIdentity6Api.App.Services.Interfaces;

public interface IAuthnService
{
    public ServiceResult<JwtSecurityToken> GenerateToken(AppUser user);
}
