using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Cliente;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.Application.MappingProfiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteDto, Cliente>().ReverseMap();
        CreateMap<CreateClienteCommand, Cliente>().ReverseMap();
        CreateMap<UpdateClienteCommand, Cliente>().ReverseMap();
    }
}