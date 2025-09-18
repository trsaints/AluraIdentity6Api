using Microsoft.AspNetCore.Authorization;

namespace AluraIdentity6Api.Infra.Authn.Requirements;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; }

    /// <summary>
    /// Este requisito de autorização verifica se o usuário atende a uma idade mínima especificada.
    /// </summary>
    public MinimumAgeRequirement(int minimumAge)
    {
        MinimumAge = minimumAge;
    }
}
