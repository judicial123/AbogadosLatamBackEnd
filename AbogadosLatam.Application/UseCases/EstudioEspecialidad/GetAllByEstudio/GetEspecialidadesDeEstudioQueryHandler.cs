using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad.Queries;

public class GetEspecialidadesDeEstudioQueryHandler : IRequestHandler<GetEspecialidadesDeEstudioQuery, List<EspecialidadDto>>
{
    private readonly IMapper _mapper;
    private readonly IEstudioEspecialidadQueryRepository _estudioEspecialidadRepository;

    public GetEspecialidadesDeEstudioQueryHandler(IMapper mapper, IEstudioEspecialidadQueryRepository estudioEspecialidadRepository)
    {
        _mapper = mapper;
        _estudioEspecialidadRepository = estudioEspecialidadRepository;
    }

    public async Task<List<EspecialidadDto>> Handle(GetEspecialidadesDeEstudioQuery request, CancellationToken cancellationToken)
    {
        // Obtener especialidades asociadas al estudio
        var especialidades = await _estudioEspecialidadRepository.ObtenerEspecialidadesDeEstudio(request.EstudioId);

        // Mapear a DTO
        var data = _mapper.Map<List<EspecialidadDto>>(especialidades);

        // Retornar la lista de especialidades en formato DTO
        return data;
    }
}