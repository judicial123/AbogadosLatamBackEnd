using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad;

public class CreateCiudadCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
    public int PaisId { get; set; } // Relación con el país
}