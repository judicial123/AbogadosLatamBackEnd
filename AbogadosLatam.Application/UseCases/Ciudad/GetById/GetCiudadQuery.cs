using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad;

public record GetCiudadQuery(int Id) : IRequest<CiudadDto>;