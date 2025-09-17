using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.Infra.Data.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AluraIdentity6Api.App.Services;

public class AuthnService : IAuthnService
{
    public ServiceResult<JwtSecurityToken> GenerateToken(AppUser user)
    {
        var jwtIssuer = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_ISSUER) 
            ?? throw new InvalidOperationException("JWT_ISSUER não configurada");

        var jwtAudience = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_AUDIENCE) 
            ?? throw new InvalidOperationException("JWT_AUDIENCE não configurada");

        Claim[] userClaims =
        [
            new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Sid, user.Cpf),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, jwtAudience),
        ];

        var jwtKey = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_KEY) 
            ?? throw new InvalidOperationException("JWT_KEY não configurada");

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));

        JwtSecurityToken token = new(jwtIssuer, 
            jwtAudience, 
            userClaims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        );

        return ServiceResult<JwtSecurityToken>.Ok(token);
    }
}
