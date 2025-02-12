using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Pais
{
    public class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, int>
    {
        private readonly IPaisCommandRepository _paisRepository;
        private readonly IMapper _mapper;

        public CreatePaisCommandHandler(IPaisCommandRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            // Mapea los datos del comando a la entidad de dominio
            var pais = _mapper.Map<Domain.Pais>(request);

            // Guarda el país en el repositorio
            await _paisRepository.CreateAsync(pais);

            // Devuelve el ID del país creado
            return pais.Id;
        }
    }
}