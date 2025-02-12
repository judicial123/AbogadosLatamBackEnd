using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class CiudadProfile : Profile
{
    public CiudadProfile()
    {
        CreateMap<Ciudad, CiudadDto>()
            .ForMember(dest => dest.NombrePais, 
                opt => opt.MapFrom(src => src.Pais != null ? src.Pais.Nombre : string.Empty))
            .ReverseMap();
        CreateMap<CreateCiudadCommand, Ciudad>().ReverseMap();
        CreateMap<UpdateCiudadCommand, Ciudad>().ReverseMap();
    }
}