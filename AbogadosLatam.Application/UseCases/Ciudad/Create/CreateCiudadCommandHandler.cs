using AutoMapper;
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class CreateCiudadCommandHandler : IRequestHandler<CreateCiudadCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IPaisRepository _paisRepository;

        public CreateCiudadCommandHandler(IMapper mapper, ICiudadRepository ciudadRepository, IPaisRepository paisRepository)
        {
            _mapper = mapper;
            _ciudadRepository = ciudadRepository;
            _paisRepository = paisRepository;
        }

        public async Task<int> Handle(CreateCiudadCommand request, CancellationToken cancellationToken)
        {
            // Validación usando el validador personalizado
            var validator = new CreateCiudadCommandValidator(_paisRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Ciudad Request", validationResult);
            }

            // Mapea el comando a la entidad de dominio
            var ciudad = _mapper.Map<Domain.Ciudad>(request);

            // Guarda la ciudad en el repositorio
            await _ciudadRepository.CreateAsync(ciudad);

            // Retorna Unit.Value para indicar que la operación se completó con éxito
            return ciudad.Id;
        }
    }
}