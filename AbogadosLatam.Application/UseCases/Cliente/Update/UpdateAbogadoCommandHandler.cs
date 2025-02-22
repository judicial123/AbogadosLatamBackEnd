using AbogadosLatam.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteCommandRepository _clienteRepository;
        private readonly IClienteQueryRepository _clienteQueryRepository;

        public UpdateClienteCommandHandler(
            IClienteCommandRepository clienteRepository, 
            IClienteQueryRepository clienteQueryRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteQueryRepository = clienteQueryRepository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            // Verifica si el cliente existe en la base de datos
            var existingCliente = await _clienteQueryRepository.GetByIdAsync(request.Id);
            if (existingCliente == null)
            {
                throw new KeyNotFoundException($"El cliente con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas
            existingCliente.FotoUrl = request.FotoUrl;
            existingCliente.Telefono = request.Whatsapp;
            existingCliente.EstadoCivil = request.EstadoCivil;

            // Guarda los cambios
            await _clienteRepository.UpdateAsync(existingCliente);

            return Unit.Value;
        }
    }
}