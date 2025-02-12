using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Model.MappingProfiles;

public class ApplicationMappingProfile: Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Pais, PaisEntity>().ReverseMap();
        CreateMap<Ciudad, CiudadEntity>().ReverseMap();
        CreateMap<Especialidad, EspecialidadEntity>().ReverseMap();
        CreateMap<Estudio, EstudioEntity>().ReverseMap();
        CreateMap<Sucursal, SucursalEntity>().ReverseMap();


    }
}