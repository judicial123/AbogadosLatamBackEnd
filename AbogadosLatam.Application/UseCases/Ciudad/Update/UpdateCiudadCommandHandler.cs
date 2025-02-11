using AutoMapper;
using AbogadosLatam.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.UseCases.Ciudad.Validators;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class UpdateCiudadCommandHandler : IRequestHandler<UpdateCiudadCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IPaisRepository _paisRepository;

        public UpdateCiudadCommandHandler(IMapper mapper, ICiudadRepository ciudadRepository, IPaisRepository paisRepository)
        {
            _mapper = mapper;
            _ciudadRepository = ciudadRepository;
            _paisRepository = paisRepository;
        }

        public async Task<int> Handle(UpdateCiudadCommand request, CancellationToken cancellationToken)
        {
            // Validación usando el validador personalizado
            var validator = new UpdateCiudadCommandValidator(_paisRepository,_ciudadRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Ciudad Update Request", validationResult);
            }

            // Verifica si la ciudad a actualizar existe
            var existingCiudad = await _ciudadRepository.GetByIdAsync(request.Id);
            if (existingCiudad == null)
            {
                throw new NotFoundException("Ciudad", request.Id);
            }

            // Mapea los cambios al objeto de dominio existente
            _mapper.Map(request, existingCiudad);

            // Actualiza la ciudad en el repositorio
            await _ciudadRepository.UpdateAsync(existingCiudad);

            // Retorna el ID de la ciudad actualizada
            return existingCiudad.Id;
        }
    }
}