using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class GetPaisQueryHandler: IRequestHandler<GetPaisQuery,PaisDto>
{
    private readonly IMapper _mapper;
    private readonly IPaisQueryRepository _paisRepository;

    public GetPaisQueryHandler(IMapper mapper, IPaisQueryRepository paisRepository)
    {
        this._mapper = mapper;
        this._paisRepository = paisRepository;
    }
    public async Task<PaisDto> Handle(GetPaisQuery request, CancellationToken cancellationToken)
    {
        
        //Query de database
        Domain.Pais pais= await _paisRepository.GetByIdAsync(request.Id); 
        
        //Convert data objects to DTO
        var data = _mapper.Map<PaisDto>(pais);
        
        //Return List of DTO
        return data;
    }
}