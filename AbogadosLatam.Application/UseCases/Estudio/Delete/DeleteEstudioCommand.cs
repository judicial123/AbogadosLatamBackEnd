using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class DeleteEstudioCommand : IRequest<Unit>
{
    public int Id { get; set; }
}