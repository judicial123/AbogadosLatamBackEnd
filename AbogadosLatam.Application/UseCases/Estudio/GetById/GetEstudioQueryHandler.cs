using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class GetEstudioQueryHandler : IRequestHandler<GetEstudioQuery, EstudioDto>
{
    private readonly IMapper _mapper;
    private readonly IEstudioQueryRepository _estudioRepository;

    public GetEstudioQueryHandler(IMapper mapper, IEstudioQueryRepository estudioRepository)
    {
        this._mapper = mapper;
        this._estudioRepository = estudioRepository;
    }

    public async Task<EstudioDto> Handle(GetEstudioQuery request, CancellationToken cancellationToken)
    {
        // Query de database
        Domain.Estudio estudio = await _estudioRepository.GetByIdAsync(request.Id); 
        
        // Convert data objects to DTO
        var data = _mapper.Map<EstudioDto>(estudio);
        
        // Return DTO
        return data;
    }
}