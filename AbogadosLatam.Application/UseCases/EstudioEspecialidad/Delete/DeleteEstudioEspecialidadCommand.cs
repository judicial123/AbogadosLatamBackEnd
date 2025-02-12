using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.EstudioEspecialidad
{
    public class DeleteEstudioEspecialidadCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}