using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal
{
    public class DeleteSucursalCommandHandler : IRequestHandler<DeleteSucursalCommand, Unit>
    {
        private readonly ISucursalCommandRepository _sucursalRepository;
        private readonly ISucursalQueryRepository _sucursalQueryRepository;

        public DeleteSucursalCommandHandler(ISucursalCommandRepository sucursalRepository, ISucursalQueryRepository sucursalQueryRepository)
        {
            _sucursalRepository = sucursalRepository;
            _sucursalQueryRepository = sucursalQueryRepository;
        }

        public async Task<Unit> Handle(DeleteSucursalCommand request, CancellationToken cancellationToken)
        {
            // Obtener la sucursal a eliminar
            var sucursalToDelete = await _sucursalQueryRepository.GetByIdAsync(request.Id);

            if (sucursalToDelete == null)
                throw new NotFoundException(nameof(Domain), request.Id);
            
            // Eliminar la sucursal del repositorio
            await _sucursalRepository.DeleteAsync(sucursalToDelete);

            return Unit.Value;
        }
    }
}