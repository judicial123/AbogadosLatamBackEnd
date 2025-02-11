using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad;

public class GetCiudadesQueryHandler : IRequestHandler<GetCiudadesQuery, List<CiudadDto>>
{
    private readonly IMapper _mapper;
    private readonly ICiudadRepository _ciudadRepository;

    public GetCiudadesQueryHandler(IMapper mapper, ICiudadRepository ciudadRepository)
    {
        this._mapper = mapper;
        this._ciudadRepository = ciudadRepository;
    }

    public async Task<List<CiudadDto>> Handle(GetCiudadesQuery request, CancellationToken cancellationToken)
    {
        // Query de database
        List<Domain.Ciudad> ciudades = await _ciudadRepository.GetAsync();

        // Convert data objects to DTO
        var data = _mapper.Map<List<CiudadDto>>(ciudades);

        // Return List of DTO
        return data;
    }
}