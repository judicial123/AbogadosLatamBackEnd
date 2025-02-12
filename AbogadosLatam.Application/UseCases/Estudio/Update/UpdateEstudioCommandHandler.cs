using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Estudio
{
    public class UpdateEstudioCommandHandler : IRequestHandler<UpdateEstudioCommand, Unit>
    {
        private readonly IEstudioCommandRepository _estudioRepository;
        private readonly IEstudioQueryRepository _estudioQueryRepository;
        private readonly IMapper _mapper;

        public UpdateEstudioCommandHandler(IEstudioCommandRepository estudioRepository, IEstudioQueryRepository estudioQueryRepository, IMapper mapper)
        {
            _estudioRepository = estudioRepository;
            _estudioQueryRepository = estudioQueryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEstudioCommand request, CancellationToken cancellationToken)
        {
            // Verifica si el estudio existe en la base de datos
            var existingEstudio = await _estudioQueryRepository.GetByIdAsync(request.Id);
            if (existingEstudio == null)
            {
                throw new KeyNotFoundException($"El estudio con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas
            existingEstudio.Nombre = request.Nombre;
            existingEstudio.Descripcion = request.Descripcion;
            existingEstudio.LogoUrl = request.Logo;

            // Guarda los cambios
            await _estudioRepository.UpdateAsync(existingEstudio);

            return Unit.Value;
        }
    }
}