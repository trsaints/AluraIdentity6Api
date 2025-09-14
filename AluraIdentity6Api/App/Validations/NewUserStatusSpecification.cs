using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Validations.Interfaces;

namespace AluraIdentity6Api.App.Validations;

public class NewUserStatusSpecification : ISpecification<AppUser>
{
    public bool IsSatisfiedBy(AppUser entity)
    {
        return !entity.EmailConfirmed && entity.LockoutEnabled;
    }
}
