using AbogadosLatam.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad
{
    public class UpdateEspecialidadCommandHandler : IRequestHandler<UpdateEspecialidadCommand, Unit>
    {
        private readonly IEspecialidadCommandRepository _especialidadRepository;
        private readonly IEspecialidadQueryRepository _especialidadQueryRepository;
        private readonly IMapper _mapper;

        public UpdateEspecialidadCommandHandler(IEspecialidadCommandRepository especialidadRepository, IEspecialidadQueryRepository especialidadQueryRepository, IMapper mapper)
        {
            _especialidadRepository = especialidadRepository;
            _especialidadQueryRepository = especialidadQueryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEspecialidadCommand request, CancellationToken cancellationToken)
        {
            // Verifica si la especialidad existe en la base de datos
            var existingEspecialidad = await _especialidadQueryRepository.GetByIdAsync(request.Id);
            if (existingEspecialidad == null)
            {
                throw new KeyNotFoundException($"La especialidad con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas
            existingEspecialidad.Nombre = request.Nombre;
            existingEspecialidad.Descripcion = request.Descripcion;

            // Guarda los cambios
            await _especialidadRepository.UpdateAsync(existingEspecialidad);

            return Unit.Value;
        }
    }
}