namespace AluraIdentity6Api.Infra.Data.Mappers.Interfaces;


public interface IMapper<D, R> where D : class
{
    public D? ToDomainModel(R value);
    public R? ToRequestModel(D model);
}
