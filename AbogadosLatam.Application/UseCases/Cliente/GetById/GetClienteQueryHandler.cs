using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.MappingProfiles.Exceptions;
using AbogadosLatam.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, ClienteDto>
    {
        private readonly IMapper _mapper;
        private readonly IClienteQueryRepository _clienteRepository;
        private readonly IPaisQueryRepository _paisRepository;
        private readonly IAuthService _authService;

        public GetClienteQueryHandler(
            IMapper mapper,
            IClienteQueryRepository clienteRepository,
            IPaisQueryRepository paisRepository,
            IAuthService authService)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _paisRepository = paisRepository;
            _authService = authService;
        }

        public async Task<ClienteDto> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            // Obtener el cliente
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Id);
            }

            var data = _mapper.Map<ClienteDto>(cliente);

            // Obtener el nombre del país asociado
            var pais = await _paisRepository.GetByIdAsync(cliente.PaisId);
            if (pais != null)
            {
                data.PaisNombre = pais.Nombre;
            }

            // Obtener la información del usuario en Identity
            var authResponse = await _authService.GetUserByIdAsync(cliente.UserId);
            if (authResponse != null)
            {
                data.Nombre = authResponse.FirstName + " " + authResponse.LastName;
                data.Email = authResponse.Email;
            }

            return data;
        }
    }
}
