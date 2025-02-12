using AbogadosLatam.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class DeleteCiudadCommandHandler : IRequestHandler<DeleteCiudadCommand, Unit>
    {
        private readonly ICiudadCommandRepository _ciudadRepository;
        private readonly ICiudadQueryRepository _ciudadQueryRepository;

        public DeleteCiudadCommandHandler(ICiudadCommandRepository ciudadRepository, ICiudadQueryRepository ciudadQueryRepository)
        {
            _ciudadRepository = ciudadRepository;
            _ciudadQueryRepository = ciudadQueryRepository;
        }

        public async Task<Unit> Handle(DeleteCiudadCommand request, CancellationToken cancellationToken)
        {
            // Intenta obtener la ciudad del repositorio
            var ciudadToDelete = await _ciudadQueryRepository.GetByIdAsync(request.Id);

            // Si la ciudad no existe, lanza una excepción
            if (ciudadToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Ciudad), request.Id);
            }

            // Elimina la ciudad del repositorio
            await _ciudadRepository.DeleteAsync(ciudadToDelete);

            // Retorna Unit.Value para indicar éxito
            return Unit.Value;
        }
    }
}