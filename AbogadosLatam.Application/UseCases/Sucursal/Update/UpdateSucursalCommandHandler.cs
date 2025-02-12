using AbogadosLatam.Application.Contracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal
{
    public class UpdateSucursalCommandHandler : IRequestHandler<UpdateSucursalCommand, Unit>
    {
        private readonly ISucursalCommandRepository _sucursalRepository;
        private readonly ISucursalQueryRepository _sucursalQueryRepository;
        private readonly IMapper _mapper;

        public UpdateSucursalCommandHandler(ISucursalCommandRepository sucursalRepository, ISucursalQueryRepository sucursalQueryRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _sucursalQueryRepository = sucursalQueryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSucursalCommand request, CancellationToken cancellationToken)
        {
            // Verifica si la sucursal existe en la base de datos
            var existingSucursal = await _sucursalQueryRepository.GetByIdAsync(request.Id);
            if (existingSucursal == null)
            {
                throw new KeyNotFoundException($"La sucursal con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas
            existingSucursal.Nombre = request.Nombre;
            existingSucursal.Direccion = request.Direccion;
            existingSucursal.Telefono = request.Telefono;
            existingSucursal.Correo = request.Correo;
            existingSucursal.Latitud = request.Latitud;
            existingSucursal.Longitud = request.Longitud;
            existingSucursal.EsPrincipal = request.EsPrincipal;

            // Guarda los cambios
            await _sucursalRepository.UpdateAsync(existingSucursal);

            return Unit.Value;
        }
    }
}