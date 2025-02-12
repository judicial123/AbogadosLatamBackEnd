using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.EstudioEspecialidad
{
    public class DeleteEstudioEspecialidadCommandHandler : IRequestHandler<DeleteEstudioEspecialidadCommand, Unit>
    {
        private readonly IEstudioEspecialidadCommandRepository _repository;
        private readonly IEstudioEspecialidadQueryRepository _queryRepository;

        public DeleteEstudioEspecialidadCommandHandler(IEstudioEspecialidadCommandRepository repository, IEstudioEspecialidadQueryRepository queryRepository)
        {
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(DeleteEstudioEspecialidadCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _queryRepository.GetByIdAsync(request.Id);

            if (entityToDelete == null)
                throw new NotFoundException(nameof(EstudioEspecialidad), request.Id);
            
            await _repository.DeleteAsync(entityToDelete);

            return Unit.Value;
        }
    }
}