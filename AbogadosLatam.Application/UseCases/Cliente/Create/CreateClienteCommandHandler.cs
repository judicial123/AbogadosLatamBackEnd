using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Contracts.Models.Identity;
using AbogadosLatam.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public CreateClienteCommandHandler(
            IClienteCommandRepository clienteRepository,
            IMapper mapper,
            IAuthService authService)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            // Registrar el usuario en Identity
            var registrationRequest = new RegistrationRequest
            {
                Email = request.Email,
                Password = request.Clave,
                FirstName = request.Nombre,
                LastName = request.Apellido,
                UserName = request.Email // Se usa el email como username
            };

            var registrationResult = await _authService.Register(registrationRequest);

            // Mapear y guardar el cliente en la base de datos
            var cliente = _mapper.Map<Domain.Cliente>(request);
            cliente.UserId = registrationResult.UserId; // Relación con Identity
            await _clienteRepository.CreateAsync(cliente);

            return cliente.Id;
        }
    }
}