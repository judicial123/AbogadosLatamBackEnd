using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Application.Contracts.Persistence;

public interface ICommandRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}