using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Pais;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class AutoMapperPais : Profile
{
    public AutoMapperPais()
    {
        CreateMap<PaisDto, Pais>().ReverseMap();
        CreateMap<CreatePaisCommand, Pais>().ReverseMap();
        CreateMap<UpdatePaisCommand, Pais>().ReverseMap();
    }
}