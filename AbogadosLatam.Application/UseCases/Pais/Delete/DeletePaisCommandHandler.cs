using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Pais
{
    public class DeletePaisCommandHandler : IRequestHandler<DeletePaisCommand, Unit>
    {
        private readonly IPaisCommandRepository _paisRepository;
        private readonly IPaisQueryRepository _paisQueryRepository;

        public DeletePaisCommandHandler(IPaisCommandRepository paisRepository, IPaisQueryRepository paisQueryRepository)
        {
            _paisRepository = paisRepository;
            _paisQueryRepository = paisQueryRepository;
        }

        public async Task<Unit> Handle(DeletePaisCommand request, CancellationToken cancellationToken)
        {
            // Mapea los datos del comando a la entidad de dominio
            var paisToDelete = await _paisQueryRepository.GetByIdAsync(request.Id);

            if (paisToDelete == null)
                throw new NotFoundException(nameof(Domain), request.Id);
            
            // Guarda el país en el repositorio
            await _paisRepository.DeleteAsync(paisToDelete);

            // Devuelve el ID del país creado
            return Unit.Value;
        }
    }
}