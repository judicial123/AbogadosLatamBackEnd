using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class GetEspecialidadesQueryHandler : IRequestHandler<GetEspecialidadesQuery, List<EspecialidadDto>>
{
    private readonly IMapper _mapper;
    private readonly IEspecialidadQueryRepository _especialidadRepository;

    public GetEspecialidadesQueryHandler(IMapper mapper, IEspecialidadQueryRepository especialidadRepository)
    {
        _mapper = mapper;
        _especialidadRepository = especialidadRepository;
    }

    public async Task<List<EspecialidadDto>> Handle(GetEspecialidadesQuery request, CancellationToken cancellationToken)
    {
        // Consulta a la base de datos
        List<Domain.Especialidad> especialidades = await _especialidadRepository.GetAsync();
        
        // Mapeo de entidades a DTOs
        var data = _mapper.Map<List<EspecialidadDto>>(especialidades);
        
        // Retorno de la lista de DTOs
        return data;
    }
}