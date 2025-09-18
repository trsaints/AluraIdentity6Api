using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Authn.Interfaces;
using AluraIdentity6Api.Infra.Data;
using AluraIdentity6Api.Infra.Data.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AluraIdentity6Api.Infra.Authn;

public class AuthnService : IAuthnService
{
    public ServiceResult<AuthResponse> GenerateToken(AppUser user)
    {
        var jwtIssuer = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_ISSUER) 
            ?? throw new ApplicationException("JWT_ISSUER não configurada");

        var jwtAudience = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_AUDIENCE) 
            ?? throw new ApplicationException("JWT_AUDIENCE não configurada");

        var expiration = DateTime.UtcNow.AddHours(1);

        Claim[] userClaims =
        [
            new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Sid, user.Cpf),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, jwtAudience),
            new Claim(JwtRegisteredClaimNames.Exp, expiration.ToString())
        ];

        var jwtKey = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_KEY) 
            ?? throw new InvalidOperationException("JWT_KEY não configurada");

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));


        JwtSecurityToken token = new(jwtIssuer, 
            jwtAudience, 
            userClaims,
            notBefore: DateTime.UtcNow,
            expires: expiration,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        );

        AuthResponse result = new()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };

        return ServiceResult<AuthResponse>.Ok(result);
    }
}
