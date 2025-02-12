using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class EstudioEspecialidadProfile : Profile
{
    public EstudioEspecialidadProfile()
    {
        // Mapeo entre la entidad intermedia y el DTO
        CreateMap<EstudioEspecialidad, EstudioEspecialidadDto>().ReverseMap();

        // Mapeo de la relación para facilitar acceso desde DTO
        CreateMap<EstudioEspecialidad, EspecialidadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Especialidad.Id))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Especialidad.Nombre))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Especialidad.Descripcion));

        CreateMap<EstudioEspecialidad, EstudioDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Estudio.Id))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Estudio.Nombre))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Estudio.Descripcion))
            .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.Estudio.LogoUrl));
    }
}