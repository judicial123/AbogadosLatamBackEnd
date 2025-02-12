using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class GetSucursalesByEstudioQueryHandler : IRequestHandler<GetSucursalesByEstudioQuery, List<SucursalDto>>
{
    private readonly IMapper _mapper;
    private readonly ISucursalQueryRepository _sucursalRepository;

    public GetSucursalesByEstudioQueryHandler(IMapper mapper, ISucursalQueryRepository sucursalRepository)
    {
        _mapper = mapper;
        _sucursalRepository = sucursalRepository;
    }

    public async Task<List<SucursalDto>> Handle(GetSucursalesByEstudioQuery request, CancellationToken cancellationToken)
    {
        // Query para obtener sucursales por EstudioId
        var sucursales = await _sucursalRepository.GetByEstudioIdAsync(request.EstudioId);

        // Convertir a DTO
        var data = _mapper.Map<List<SucursalDto>>(sucursales);

        // Retornar la lista de DTO
        return data;
    }
}