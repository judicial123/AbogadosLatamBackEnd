using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class UpdatePaisCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}