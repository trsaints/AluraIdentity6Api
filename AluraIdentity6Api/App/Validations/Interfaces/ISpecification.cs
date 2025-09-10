using AluraIdentity6Api.App.Data.Models.Interfaces;

namespace AluraIdentity6Api.App.Validations.Interfaces;

public interface ISpecification<T> where T : ITrackable
{
    bool IsSatisfiedBy(T entity);
}
