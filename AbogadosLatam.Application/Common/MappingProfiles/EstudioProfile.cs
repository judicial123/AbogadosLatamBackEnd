using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Estudio;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class EstudioProfile : Profile
{
    public EstudioProfile()
    {
        CreateMap<EstudioDto, Estudio>().ReverseMap();
        CreateMap<CreateEstudioCommand, Estudio>().ReverseMap();
        CreateMap<UpdateEstudioCommand, Estudio>().ReverseMap();
    }
}