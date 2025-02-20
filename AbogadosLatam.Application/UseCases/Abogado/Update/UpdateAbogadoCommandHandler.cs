using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class UpdateAbogadoCommandHandler : IRequestHandler<UpdateAbogadoCommand, Unit>
    {
        private readonly IAbogadoCommandRepository _abogadoRepository;
        private readonly IAbogadoQueryRepository _abogadoQueryRepository;
        private readonly IMapper _mapper;

        public UpdateAbogadoCommandHandler(
            IAbogadoCommandRepository abogadoRepository, 
            IAbogadoQueryRepository abogadoQueryRepository, 
            IMapper mapper)
        {
            _abogadoRepository = abogadoRepository;
            _abogadoQueryRepository = abogadoQueryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAbogadoCommand request, CancellationToken cancellationToken)
        {
            // Verifica si el abogado existe en la base de datos
            var existingAbogado = await _abogadoQueryRepository.GetByIdAsync(request.Id);
            if (existingAbogado == null)
            {
                throw new KeyNotFoundException($"El abogado con ID {request.Id} no existe.");
            }

            // Actualiza las propiedades específicas (sin modificar el Email ni el Estudio)
            existingAbogado.Descripcion = request.Descripcion;
            existingAbogado.FotoUrl = request.FotoUrl;
            existingAbogado.Whatsapp = request.Whatsapp;

            // Guarda los cambios
            await _abogadoRepository.UpdateAsync(existingAbogado);

            return Unit.Value;
        }
    }
}