using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class UpdatePerroCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
