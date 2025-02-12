using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class GetEstudiosQuery : IRequest<List<EstudioDto>>
{
    
}

//public record GetEstudioQuery(int Id) : IRequest<EstudioDto>;