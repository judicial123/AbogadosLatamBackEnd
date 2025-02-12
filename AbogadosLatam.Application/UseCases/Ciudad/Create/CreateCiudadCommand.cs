using AbogadosLatam.Application.UseCases.Ciudad.Common;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad;

public class CreateCiudadCommand : BasePaisRequest, IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
    
}