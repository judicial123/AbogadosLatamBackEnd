using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class GetClienteQuery : IRequest<ClienteDto>
    {
        public int Id { get; set; }

        public GetClienteQuery(int id)
        {
            Id = id;
        }
    }
}