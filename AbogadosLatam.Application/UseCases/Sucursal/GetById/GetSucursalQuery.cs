using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class GetSucursalQuery(int id) : IRequest<SucursalDto>
{
    public int Id { get; set; } = id;

    // Constructor para inicializar con el id
}