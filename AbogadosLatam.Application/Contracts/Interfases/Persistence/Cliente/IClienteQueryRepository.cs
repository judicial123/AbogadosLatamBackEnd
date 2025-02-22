using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Contracts
{
    public interface IClienteQueryRepository : IQueryRepository<Cliente>
    {
    }
}