using AluraIdentity6Api.Infra.Authn.Constants;
using AluraIdentity6Api.Infra.Authn.Requirements;
using AluraIdentity6Api.Infra.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AluraIdentity6Api.Infra.Authn;

public static class AuthnExtensions
{
    /// <summary>
    /// Configura as políticas de autorização da aplicação durante a fase de build.
    /// </summary>
    /// <param name="services">O container de DI do ASP.NET Core</param>
    public static void AddAuthnConfiguration(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(AuthorizationConstants.MinimumAgePolicy, policy =>
            {
                policy.AddRequirements(new MinimumAgeRequirement(21));
                policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
            });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = JwtSettings.TokenValidationParameters();

            options.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    var token = context.Request.Cookies["auth_token"];

                    if (!string.IsNullOrEmpty(token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                }
            };
        });
    }
}
