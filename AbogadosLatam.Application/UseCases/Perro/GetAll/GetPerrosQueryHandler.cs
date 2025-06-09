using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class GetPerrosQueryHandler : IRequestHandler<GetPerrosQuery, List<PerroDto>>
{
    private readonly IMapper _mapper;
    private readonly IPerroQueryRepository _perroRepository;

    public GetPerrosQueryHandler(IMapper mapper, IPerroQueryRepository perroRepository)
    {
        _mapper = mapper;
        _perroRepository = perroRepository;
    }

    public async Task<List<PerroDto>> Handle(GetPerrosQuery request, CancellationToken cancellationToken)
    {
        var perros = await _perroRepository.GetAsync();
        var data = _mapper.Map<List<PerroDto>>(perros);
        return data;
    }
}
