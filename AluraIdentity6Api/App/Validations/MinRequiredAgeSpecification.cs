using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Validations.Interfaces;

namespace AluraIdentity6Api.App.Validations;

public class MinRequiredAgeSpecification : ISpecification<AppUser>
{
    public bool IsSatisfiedBy(AppUser entity)
    {
        var age = DateTime.Today.Year - entity.BirthDate?.Year;

        if (age is null or < 21) return false;

        return true;
    }
}
