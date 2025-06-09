using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class DeletePerroCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
