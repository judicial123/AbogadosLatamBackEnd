using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Sucursal;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class SucursalProfile : Profile
{
    public SucursalProfile()
    {
        CreateMap<SucursalDto, Sucursal>().ReverseMap();
        CreateMap<CreateSucursalCommand, Sucursal>().ReverseMap();
        CreateMap<UpdateSucursalCommand, Sucursal>().ReverseMap();
    }
}