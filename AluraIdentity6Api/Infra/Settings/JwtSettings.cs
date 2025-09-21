using AluraIdentity6Api.Infra.Data.Constants;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AluraIdentity6Api.Infra.Settings;

public static class JwtSettings
{
    public static TokenValidationParameters TokenValidationParameters()
    {
        var jwtIssuer = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_ISSUER)
            ?? throw new ApplicationException("JWT_ISSUER não configurada");

        var jwtAudience = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_AUDIENCE)
            ?? throw new ApplicationException("JWT_AUDIENCE não configurada");

        var jwtKey = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_KEY)
            ?? throw new InvalidOperationException("JWT_KEY não configurada");

        return new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    }
}
