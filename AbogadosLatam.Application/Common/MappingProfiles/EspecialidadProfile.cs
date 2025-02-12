using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Especialidad;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class EspecialidadProfile : Profile
{
    public EspecialidadProfile()
    {
        CreateMap<CreateEspecialidadCommand, Especialidad>().ReverseMap();
        CreateMap<EspecialidadDto, Especialidad>().ReverseMap();
        CreateMap<UpdateEspecialidadCommand, Especialidad>().ReverseMap();
    }
}