using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Contracts.Models.Identity;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class CreateAbogadoCommandHandler : IRequestHandler<CreateAbogadoCommand, int>
    {
        private readonly IAbogadoCommandRepository _abogadoRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public CreateAbogadoCommandHandler(
            IAbogadoCommandRepository abogadoRepository,
            IMapper mapper,
            IAuthService authService)
        {
            _abogadoRepository = abogadoRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<int> Handle(CreateAbogadoCommand request, CancellationToken cancellationToken)
        {
            // Registrar el usuario en Identity
            var registrationRequest = new RegistrationRequest
            {
                Email = request.Email,
                Password = request.Clave,
                FirstName = request.Nombre,
                LastName = request.Apellido,
                UserName = request.Email // Asignamos el email como nombre de usuario
            };

            var registrationResult = await _authService.Register(registrationRequest);

            // Mapear y guardar el abogado en la base de datos
            var abogado = _mapper.Map<Domain.Abogado>(request);
            abogado.UserId = registrationResult.UserId; 
            abogado.Descripcion = request.Descripcion;
            abogado.FotoUrl = request.FotoUrl;
            abogado.Whatsapp = request.Whatsapp;// Relacionar con Identity
            await _abogadoRepository.CreateAsync(abogado);

            return abogado.Id;
        }
    }
}