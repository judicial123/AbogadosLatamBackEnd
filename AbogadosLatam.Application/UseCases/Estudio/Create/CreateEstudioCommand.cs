using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class CreateEstudioCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
}