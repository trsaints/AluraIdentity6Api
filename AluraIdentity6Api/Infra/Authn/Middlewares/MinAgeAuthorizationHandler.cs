using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Authn.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AluraIdentity6Api.Infra.Authn.Middlewares;

public class MinAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    private readonly ILogger<MinAgeAuthorizationHandler> _logger;

    public MinAgeAuthorizationHandler(ILogger<MinAgeAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        MinimumAgeRequirement requirement)
    {
        var dateOfBirthClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

        if (!DateTime.TryParse(dateOfBirthClaim?.Value ?? string.Empty, 
            out var userBirthDate))
        {
            _logger.LogError("Failed to parse date of birth claim for user {User}. Claim value: {ClaimValue}",
                context.User.Identity?.Name ?? "<unknown>",
                dateOfBirthClaim?.Value ?? "<null>");

            context.Fail();

            return Task.CompletedTask;
        }

        var today = DateTime.Today;
        var age = today.Year - userBirthDate.Year;

        if (userBirthDate > today.AddYears(-age))
        {
            age--;
        }

        if (age >= requirement.MinimumAge)
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }

        _logger.LogError("Failed to authorize user {User} for minimum age {MinAge}. User age: {Age}",
            context.User.Identity?.Name ?? "<unknown>",
            requirement.MinimumAge,
            age);

        context.Fail();

        return Task.CompletedTask;
    }
}
