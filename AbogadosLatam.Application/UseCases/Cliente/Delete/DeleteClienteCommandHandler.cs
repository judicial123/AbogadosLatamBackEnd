using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository;

        public DeleteClienteCommandHandler(IClienteCommandRepository clienteRepository, IClienteQueryRepository clienteQueryRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _clienteQueryRepository.GetByIdAsync(request.Id);

            if (clienteToDelete == null)
                throw new NotFoundException(nameof(Cliente), request.Id);
            
            await _clienteRepository.DeleteAsync(clienteToDelete);

            return Unit.Value;
        }
    }
}