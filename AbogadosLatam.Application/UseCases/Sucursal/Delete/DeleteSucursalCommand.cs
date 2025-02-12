using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class DeleteSucursalCommand : IRequest<Unit>
{
    public int Id { get; set; }
}