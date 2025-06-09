using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class CreatePerroCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
}
