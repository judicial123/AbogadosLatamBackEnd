using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class GetAbogadosPorEstudioQuery : IRequest<List<AbogadoDto>>
    {
        public int EstudioId { get; set; }
        public GetAbogadosPorEstudioQuery(int id)
        {
            EstudioId = id;
        }
    }
}