using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class GetPaisesQuery : IRequest<List<PaisDto>>
{
    
}


//public record GetPaisQuery(int Id) : IRequest<PaisDto>;