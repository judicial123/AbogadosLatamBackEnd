using AbogadosLatam.Domain;
using AbogadosLatam.Application.Contracts.Persistence;

namespace AbogadosLatam.Application.Contracts
{
    public interface IEstudioEspecialidadCommandRepository : ICommandRepository<EstudioEspecialidad>
    {
        Task AsignarEspecialidadAEstudio(int estudioId, int especialidadId);
    }
}