using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.EstudioEspecialidad
{
    public class AsignarEspecialidadAEstudioCommand : IRequest
    {
        public int EstudioId { get; set; }
        public int EspecialidadId { get; set; }
    }
}