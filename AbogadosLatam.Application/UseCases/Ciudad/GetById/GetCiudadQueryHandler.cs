using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class GetCiudadQueryHandler : IRequestHandler<GetCiudadQuery, CiudadDto>
    {
        private readonly IMapper _mapper;
        private readonly ICiudadQueryRepository _ciudadRepository;

        public GetCiudadQueryHandler(IMapper mapper, ICiudadQueryRepository ciudadRepository)
        {
            _mapper = mapper;
            _ciudadRepository = ciudadRepository;
        }

        public async Task<CiudadDto> Handle(GetCiudadQuery request, CancellationToken cancellationToken)
        {
            // Consulta a la base de datos
            Domain.Ciudad ciudad = await _ciudadRepository.GetByIdAsync(request.Id,"Pais");

            // Convertir datos a DTO
            var data = _mapper.Map<CiudadDto>(ciudad);

            // Retornar el DTO
            return data;
        }
    }
}