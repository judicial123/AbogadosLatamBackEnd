using AbogadosLatam.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Contracts.Persistence;

public interface IEstudioEspecialidadQueryRepository: IQueryRepository<EstudioEspecialidad>
{
    Task<List<Especialidad>> ObtenerEspecialidadesDeEstudio(int estudioId);
}