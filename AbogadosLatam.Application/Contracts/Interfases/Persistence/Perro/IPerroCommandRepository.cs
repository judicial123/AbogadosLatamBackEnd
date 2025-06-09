using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Domain;

namespace AbogadosLatam.Application.Contracts;

public interface IPerroCommandRepository : ICommandRepository<Perro>
{
}
