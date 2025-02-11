using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad;

public class GetCiudadesQuery : IRequest<List<CiudadDto>>
{
    
}

//public record GetCiudadesQuery : IRequest<List<CiudadDto>>;