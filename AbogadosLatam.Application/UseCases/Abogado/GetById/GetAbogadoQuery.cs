using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio
{
    public class GetAbogadoQuery : IRequest<AbogadoDto>
    {
        public int Id { get; set; }
        public GetAbogadoQuery(int id)
        {
            Id = id;
        }
    }
}