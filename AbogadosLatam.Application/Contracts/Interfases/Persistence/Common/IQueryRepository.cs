using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Application.Contracts.Persistence;

public interface IQueryRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id,params string[] includes);
    Task<List<T>> GetAsync(params string[] includes);
}