using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts.Persistence;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad
{
    public class CreateEspecialidadCommandHandler : IRequestHandler<CreateEspecialidadCommand, int>
    {
        private readonly IEspecialidadCommandRepository _especialidadRepository;
        private readonly IMapper _mapper;

        public CreateEspecialidadCommandHandler(IEspecialidadCommandRepository especialidadRepository, IMapper mapper)
        {
            _especialidadRepository = especialidadRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEspecialidadCommand request, CancellationToken cancellationToken)
        {
            // Mapea los datos del comando a la entidad de dominio
            var especialidad = _mapper.Map<Domain.Especialidad>(request);

            // Guarda la especialidad en el repositorio
            await _especialidadRepository.CreateAsync(especialidad);

            // Devuelve el ID de la especialidad creada
            return especialidad.Id;
        }
    }
}