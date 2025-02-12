using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Pais
{
    public class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, Unit>
    {
        private readonly IPaisCommandRepository _paisRepository;
        private readonly IPaisQueryRepository _paisQueryRepository;
        private readonly IMapper _mapper;

        public UpdatePaisCommandHandler(IPaisCommandRepository paisRepository, IPaisQueryRepository paisQueryRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            _paisQueryRepository = paisQueryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
        {
            // Verifica si el país existe en la base de datos
            var existingPais = await _paisQueryRepository.GetByIdAsync(request.Id);
            if (existingPais == null)
            {
                throw new KeyNotFoundException($"El país con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas
            existingPais.Nombre = request.Nombre;

            // Guarda los cambios
            await _paisRepository.UpdateAsync(existingPais);

            return Unit.Value;
        }
    }
}