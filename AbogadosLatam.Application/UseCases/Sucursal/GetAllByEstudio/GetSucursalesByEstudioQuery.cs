using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class GetSucursalesByEstudioQuery : IRequest<List<SucursalDto>>
{
    public int EstudioId { get; set; }
}