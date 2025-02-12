using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class GetSucursalQueryHandler: IRequestHandler<GetSucursalQuery, SucursalDto>
{
    private readonly IMapper _mapper;
    private readonly ISucursalQueryRepository _sucursalRepository;

    public GetSucursalQueryHandler(IMapper mapper, ISucursalQueryRepository sucursalRepository)
    {
        this._mapper = mapper;
        this._sucursalRepository = sucursalRepository;
    }

    public async Task<SucursalDto> Handle(GetSucursalQuery request, CancellationToken cancellationToken)
    {
        // Query de database con relaciones cargadas
        Domain.Sucursal sucursal = await _sucursalRepository.GetByIdAsync(request.Id, "Ciudad", "Estudio"); 

        // Convert data objects to DTO
        var data = _mapper.Map<SucursalDto>(sucursal);
        
        // Return DTO
        return data;
    }
}