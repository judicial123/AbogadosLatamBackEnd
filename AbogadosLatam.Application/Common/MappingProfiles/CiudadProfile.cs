using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class CiudadProfile : Profile
{
    public CiudadProfile()
    {
        CreateMap<CiudadDto, Ciudad>().ReverseMap();
        CreateMap<CreateCiudadCommand, Ciudad>().ReverseMap();
        CreateMap<UpdateCiudadCommand, Ciudad>().ReverseMap();
    }
}