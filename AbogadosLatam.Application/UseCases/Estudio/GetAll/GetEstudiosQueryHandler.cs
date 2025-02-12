using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class GetEstudiosQueryHandler : IRequestHandler<GetEstudiosQuery, List<EstudioDto>>
{
    private readonly IMapper _mapper;
    private readonly IEstudioQueryRepository _estudioRepository;

    public GetEstudiosQueryHandler(IMapper mapper, IEstudioQueryRepository estudioRepository)
    {
        this._mapper = mapper;
        this._estudioRepository = estudioRepository;
    }

    public async Task<List<EstudioDto>> Handle(GetEstudiosQuery request, CancellationToken cancellationToken)
    {
        // Query de database
        List<Domain.Estudio> estudios = await _estudioRepository.GetAsync();

        // Convert data objects to DTO
        var data = _mapper.Map<List<EstudioDto>>(estudios);

        // Return List of DTO
        return data;
    }
}