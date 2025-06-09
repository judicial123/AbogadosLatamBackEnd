using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class GetPerroQueryHandler : IRequestHandler<GetPerroQuery, PerroDto>
{
    private readonly IMapper _mapper;
    private readonly IPerroQueryRepository _perroRepository;

    public GetPerroQueryHandler(IMapper mapper, IPerroQueryRepository perroRepository)
    {
        _mapper = mapper;
        _perroRepository = perroRepository;
    }

    public async Task<PerroDto> Handle(GetPerroQuery request, CancellationToken cancellationToken)
    {
        var perro = await _perroRepository.GetByIdAsync(request.Id);
        var data = _mapper.Map<PerroDto>(perro);
        return data;
    }
}
