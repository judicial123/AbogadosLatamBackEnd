using AbogadosLatam.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts.Persistence;

namespace AbogadosLatam.Application.Contracts
{
    public interface ISucursalQueryRepository : IQueryRepository<Sucursal>
    {
        Task<List<Sucursal>> GetByEstudioIdAsync(int estudioId);
    }
}