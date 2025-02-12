using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class DeleteEspecialidadCommand : IRequest<Unit>
{
    public int Id { get; set; }
}