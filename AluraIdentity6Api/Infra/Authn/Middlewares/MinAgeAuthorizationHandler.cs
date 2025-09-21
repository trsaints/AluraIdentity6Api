using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Authn.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AluraIdentity6Api.Infra.Authn.Middlewares;

public class MinAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    private readonly UserManager<AppUser> _userManager;

    public MinAgeAuthorizationHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        MinimumAgeRequirement requirement)
    {
        Console.WriteLine("MinAgeAuthorizationHandler: Iniciando verificação de autorização");
        Console.WriteLine($"User.Identity.IsAuthenticated: {context.User.Identity?.IsAuthenticated}");
        Console.WriteLine($"Claims count: {context.User.Claims.Count()}");

        // Log todos os claims do usuário
        foreach (var claim in context.User.Claims)
        {
            Console.WriteLine($"  User Claim: {claim.Type} = {claim.Value}");
        }

        // Primeiro, tentar obter a data de nascimento do claim
        var dateOfBirthClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

        DateTime? birthDate = null;

        if (dateOfBirthClaim != null && DateTime.TryParse(dateOfBirthClaim.Value, out var parsedDate))
        {
            birthDate = parsedDate;
            Console.WriteLine($"MinAgeAuthorizationHandler: Data de nascimento obtida do claim: {birthDate}");
        }
        else
        {
            Console.WriteLine("MinAgeAuthorizationHandler: Claim DateOfBirth não encontrado, buscando no banco");
            
            // Se não conseguir do claim, buscar do banco de dados
            var user = await _userManager.GetUserAsync(context.User);
            if (user != null)
            {
                birthDate = user.BirthDate;
                Console.WriteLine($"MinAgeAuthorizationHandler: Data de nascimento obtida do banco: {birthDate}");
            }
            else
            {
                Console.WriteLine("MinAgeAuthorizationHandler: Usuário não encontrado no banco");
            }
        }

        if (birthDate == null)
        {
            Console.WriteLine("MinAgeAuthorizationHandler: FAIL - Data de nascimento não encontrada");
            context.Fail();
            return;
        }

        // Calcular idade
        var today = DateTime.Today;
        var age = today.Year - birthDate.Value.Year;

        if (birthDate > today.AddYears(-age))
        {
            age--;
        }

        Console.WriteLine($"MinAgeAuthorizationHandler: Idade calculada: {age}, Idade mínima requerida: {requirement.MinimumAge}");

        // Verificar se atende ao requisito de idade mínima
        if (age >= requirement.MinimumAge)
        {
            Console.WriteLine("MinAgeAuthorizationHandler: SUCCESS - Requisito atendido");
            context.Succeed(requirement);
        }
        else
        {
            Console.WriteLine("MinAgeAuthorizationHandler: FAIL - Idade insuficiente");
            context.Fail();
        }
    }
}
