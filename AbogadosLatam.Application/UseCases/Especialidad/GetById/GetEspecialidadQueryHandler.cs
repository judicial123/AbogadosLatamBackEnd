using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class GetEspecialidadQueryHandler : IRequestHandler<GetEspecialidadQuery, EspecialidadDto>
{
    private readonly IMapper _mapper;
    private readonly IEspecialidadQueryRepository _especialidadRepository;

    public GetEspecialidadQueryHandler(IMapper mapper, IEspecialidadQueryRepository especialidadRepository)
    {
        _mapper = mapper;
        _especialidadRepository = especialidadRepository;
    }

    public async Task<EspecialidadDto> Handle(GetEspecialidadQuery request, CancellationToken cancellationToken)
    {
        // Consulta a la base de datos
        Domain.Especialidad especialidad = await _especialidadRepository.GetByIdAsync(request.Id);

        // Mapeo de entidad a DTO
        var data = _mapper.Map<EspecialidadDto>(especialidad);
        
        // Retorno del DTO
        return data;
    }
}