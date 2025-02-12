using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.EstudioEspecialidad
{
    public class AsignarEspecialidadAEstudioCommandHandler : IRequestHandler<AsignarEspecialidadAEstudioCommand>
    {
        private readonly IEstudioEspecialidadCommandRepository _repository;

        public AsignarEspecialidadAEstudioCommandHandler(IEstudioEspecialidadCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AsignarEspecialidadAEstudioCommand request, CancellationToken cancellationToken)
        {
            await _repository.AsignarEspecialidadAEstudio(request.EstudioId, request.EspecialidadId);
        }
    }
}