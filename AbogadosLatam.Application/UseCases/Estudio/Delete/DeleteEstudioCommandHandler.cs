using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Estudio
{
    public class DeleteEstudioCommandHandler : IRequestHandler<DeleteEstudioCommand, Unit>
    {
        private readonly IEstudioCommandRepository _estudioRepository;
        private readonly IEstudioQueryRepository _estudioQueryRepository;

        public DeleteEstudioCommandHandler(IEstudioCommandRepository estudioRepository, IEstudioQueryRepository estudioQueryRepository)
        {
            _estudioRepository = estudioRepository;
            _estudioQueryRepository = estudioQueryRepository;
        }

        public async Task<Unit> Handle(DeleteEstudioCommand request, CancellationToken cancellationToken)
        {
            var estudioToDelete = await _estudioQueryRepository.GetByIdAsync(request.Id);

            if (estudioToDelete == null)
                throw new NotFoundException(nameof(Estudio), request.Id);
            
            await _estudioRepository.DeleteAsync(estudioToDelete);

            return Unit.Value;
        }
    }
}