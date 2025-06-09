using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class GetPerrosQuery : IRequest<List<PerroDto>>
{
}
