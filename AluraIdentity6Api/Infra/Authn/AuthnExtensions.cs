using AluraIdentity6Api.Infra.Authn.Constants;
using AluraIdentity6Api.Infra.Authn.Requirements;

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
            });
    }
}
