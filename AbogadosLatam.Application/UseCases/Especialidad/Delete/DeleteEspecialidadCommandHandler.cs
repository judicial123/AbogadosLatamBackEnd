using AbogadosLatam.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad
{
    public class DeleteEspecialidadCommandHandler : IRequestHandler<DeleteEspecialidadCommand, Unit>
    {
        private readonly IEspecialidadCommandRepository _especialidadRepository;
        private readonly IEspecialidadQueryRepository _especialidadQueryRepository;

        public DeleteEspecialidadCommandHandler(IEspecialidadCommandRepository especialidadRepository, IEspecialidadQueryRepository especialidadQueryRepository)
        {
            _especialidadRepository = especialidadRepository;
            _especialidadQueryRepository = especialidadQueryRepository;
        }

        public async Task<Unit> Handle(DeleteEspecialidadCommand request, CancellationToken cancellationToken)
        {
            // Obtiene la especialidad por ID
            var especialidadToDelete = await _especialidadQueryRepository.GetByIdAsync(request.Id);

            if (especialidadToDelete == null)
                throw new NotFoundException(nameof(Domain.Especialidad), request.Id);
            
            // Elimina la especialidad del repositorio
            await _especialidadRepository.DeleteAsync(especialidadToDelete);

            return Unit.Value;
        }
    }
}