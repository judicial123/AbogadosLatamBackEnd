using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Pais;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class PaisProfile : Profile
{
    public PaisProfile()
    {
        CreateMap<PaisDto, Pais>().ReverseMap();
        CreateMap<CreatePaisCommand, Pais>().ReverseMap();
        CreateMap<UpdatePaisCommand, Pais>().ReverseMap();
    }
}