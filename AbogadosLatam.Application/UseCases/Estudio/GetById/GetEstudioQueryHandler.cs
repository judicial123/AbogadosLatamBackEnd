using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Domain;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class GetEstudioQueryHandler : IRequestHandler<GetEstudioQuery, EstudioDto>
{
    private readonly IMapper _mapper;
    private readonly IEstudioQueryRepository _estudioRepository;
    private readonly ISucursalQueryRepository _sucursalRepository; // Se inyecta ISucursalQueryRepository

    public GetEstudioQueryHandler(IMapper mapper, IEstudioQueryRepository estudioRepository, ISucursalQueryRepository sucursalRepository)
    {
        this._mapper = mapper;
        this._estudioRepository = estudioRepository;
        this._sucursalRepository = sucursalRepository;
    }

    public async Task<EstudioDto> Handle(GetEstudioQuery request, CancellationToken cancellationToken)
    {
        // Obtener el estudio
        var estudio = await _estudioRepository.GetByIdAsync(request.Id);
        var data = _mapper.Map<EstudioDto>(estudio);

        // Obtener todas las sucursales del estudio
        var sucursales = await _sucursalRepository.GetByEstudioIdAsync(request.Id);

        // Filtrar la sucursal principal
        var sucursalPrincipal = sucursales.FirstOrDefault(s => s.EsPrincipal);
        if (sucursalPrincipal != null)
        {
            data.SucursalPrincipal = _mapper.Map<SucursalDto>(sucursalPrincipal);
        }

        return data;
    }
}