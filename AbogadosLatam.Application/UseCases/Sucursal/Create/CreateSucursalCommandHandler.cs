using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal
{
    public class CreateSucursalCommandHandler : IRequestHandler<CreateSucursalCommand, int>
    {
        private readonly ISucursalCommandRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public CreateSucursalCommandHandler(ISucursalCommandRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSucursalCommand request, CancellationToken cancellationToken)
        {
            // Mapea los datos del comando a la entidad de dominio
            var sucursal = _mapper.Map<Domain.Sucursal>(request);

            // Guarda la sucursal en el repositorio
            await _sucursalRepository.CreateAsync(sucursal);

            // Devuelve el ID de la sucursal creada
            return sucursal.Id;
        }
    }
}