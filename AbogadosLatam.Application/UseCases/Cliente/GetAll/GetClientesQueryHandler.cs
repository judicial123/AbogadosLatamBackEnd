using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, List<ClienteDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClienteQueryRepository _clienteRepository;

        public GetClientesQueryHandler(IMapper mapper, IClienteQueryRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteDto>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            // Consulta a la base de datos
            List<Domain.Cliente> clientes = await _clienteRepository.GetAsync();
            
            // Mapeo de entidades a DTOs
            var data = _mapper.Map<List<ClienteDto>>(clientes);
            
            // Retorno de la lista de DTOs
            return data;
        }
    }
}