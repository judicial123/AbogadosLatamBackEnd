using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Abogado;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class AbogadoProfile : Profile
{
    public AbogadoProfile()
    {
        CreateMap<AbogadoDto, Abogado>().ReverseMap();
        CreateMap<CreateAbogadoCommand, Abogado>().ReverseMap();
        CreateMap<UpdateAbogadoCommand, Abogado>().ReverseMap();
    }
}