using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class DeleteAbogadoCommandHandler : IRequestHandler<DeleteAbogadoCommand, Unit>
    {
        private readonly IAbogadoCommandRepository _abogadoRepository;
        private readonly IAbogadoQueryRepository _abogadoQueryRepository;

        public DeleteAbogadoCommandHandler(IAbogadoCommandRepository abogadoRepository, IAbogadoQueryRepository abogadoQueryRepository)
        {
            _abogadoRepository = abogadoRepository;
            _abogadoQueryRepository = abogadoQueryRepository;
        }

        public async Task<Unit> Handle(DeleteAbogadoCommand request, CancellationToken cancellationToken)
        {
            var abogadoToDelete = await _abogadoQueryRepository.GetByIdAsync(request.Id);

            if (abogadoToDelete == null)
                throw new NotFoundException(nameof(Abogado), request.Id);
            
            await _abogadoRepository.DeleteAsync(abogadoToDelete);

            return Unit.Value;
        }
    }
}