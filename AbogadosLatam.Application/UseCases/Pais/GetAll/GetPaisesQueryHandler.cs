using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class GetPaisesQueryHandler: IRequestHandler<GetPaisesQuery,List<PaisDto>>
{
    private readonly IMapper _mapper;
    private readonly IPaisRepository _paisRepository;

    public GetPaisesQueryHandler(IMapper mapper, IPaisRepository paisRepository)
    {
        this._mapper = mapper;
        this._paisRepository = paisRepository;
    }
    public async Task<List<PaisDto>> Handle(GetPaisesQuery request, CancellationToken cancellationToken)
    {
        
        //Query de database
        List<Domain.Pais> paises= await _paisRepository.GetAsync(); 
        
        //Convert data objects to DTO
        var data = _mapper.Map<List<PaisDto>>(paises);
        
        //Return List of DTO
        return data;
    }
}